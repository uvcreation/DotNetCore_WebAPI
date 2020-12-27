using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Middlewares;

namespace WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API");
            });
        }
        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ResponseTimeMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
