using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Middlewares;

namespace WebAPI.Extensions
{
    /// <summary>
    /// Application Builder Extensions
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Add Swagger UI
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API");
            });
        }

        /// <summary>
        /// Add Middlewares 
        /// </summary>
        /// <param name="app"></param>
        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
            app.UseMiddleware<ResponseTimeMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
