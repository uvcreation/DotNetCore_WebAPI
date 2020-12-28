using Microsoft.AspNetCore.Http;
using System;
using Serilog;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Business.Exceptions;
using WebAPI.Business.Models;

namespace WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = Log.ForContext<ErrorHandlerMiddleware>();
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    ApiException e => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException e => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };

                var responseModel = new Response { 
                    Message = error?.Message,
                    Description = error.StackTrace,
                    Code = response.StatusCode
                };

                _logger.Error($"Message: {responseModel.Message}, StackTrace: {responseModel.Description}");
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
