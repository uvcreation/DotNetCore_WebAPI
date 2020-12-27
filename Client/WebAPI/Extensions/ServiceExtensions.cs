using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebAPI.Repository.Entities;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        private readonly static string MyAllowSpecificOrigin = "*"; 
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(MyAllowSpecificOrigin, builder =>
                {
                    builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebApi",
                    Description = "The WebApi crud operation sample project.",
                    Contact = new OpenApiContact
                    {
                        Name = "Uttam Vyas",
                        Email = "uttamvs031@gmail.com"
                    }
                });
            });
        }

        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSetting>(option => configuration.GetSection("ConnectionStrings").Bind(option));
        }
    }
}
