using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class ResponseTimeMiddleware
    {
        // Name of the Response Header, Custom Headers starts with "X-"  
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;

        private readonly ILogger _logger = Log.ForContext<ResponseTimeMiddleware>();
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public Task InvokeAsync(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();

            _logger.Information($"Request {context.Request.Path} calls...");

            context.Response.OnStarting(() =>
            {

                // Stop the timer information and calculate the time   
                watch.Stop();

                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                // Add the Response time information in the Response headers.   
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();

                _logger.Information($"Request {context.Request.Path} complete response in {responseTimeForCompleteRequest} Milliseconds time");
                return Task.CompletedTask;
            });

            // Call the next delegate/middleware in the pipeline   
            return this._next(context);
        }
    }
}
