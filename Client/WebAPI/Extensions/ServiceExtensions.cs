using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.IO;
using WebAPI.Business.Models;
using WebAPI.Repository.Entities;

namespace WebAPI.Extensions
{
    /// <summary>
    /// Service Extensions
    /// </summary>
    public static class ServiceExtensions
    {
        private readonly static string MyAllowSpecificOrigin = "*";

        /// <summary>
        /// Add Cors Service
        /// </summary>
        /// <param name="services"></param>
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

        /// <summary>
        /// Add Swagger Service
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebApi",
                    Description = "WebApi Crud Operation",
                    Contact = new OpenApiContact
                    {
                        Name = "Uttam Vyas",
                        Email = "uttamvs031@gmail.com"
                    }
                });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert Jwt Token with Bearer right before the token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }});
            });
        }

        /// <summary>
        /// Bind the database connection string
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSetting>(option => configuration.GetSection("ConnectionStrings").Bind(option));
        }

        /// <summary>
        /// Add the application settings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }

        /// <summary>
        /// Add serilog service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddLogging(this IServiceCollection services, IConfiguration configuration)
        {
            var isLoggingEnabled = configuration.GetValue<bool>("Services:Logging_Enabled");
            string logDirectory = string.Empty;

#if DEBUG
            logDirectory = @"C:\Logs\WebApi\";
#else
                logDirectory = configuration.GetValue<string>("Services:File_Logs_Directory");
#endif

            var txtLogFilePath = Path.Combine(logDirectory, "log.txt");
            var jsonLogFilePath = Path.Combine(logDirectory, "log.json");

            var outputTemplate = "{Timestamp:o} [{Level:u3}] ({Application}/{MachineName}/{ThreadId}) {Message}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .Filter.ByExcluding(_ => !isLoggingEnabled)
                .ReadFrom.Configuration(configuration)
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File(txtLogFilePath, outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, retainedFileCountLimit: null, shared: true)
                .WriteTo.File(formatter: new JsonFormatter(), jsonLogFilePath, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, retainedFileCountLimit: null, shared: true)
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
