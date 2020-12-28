using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Business.Core;
using WebAPI.Business.Implementation;
using WebAPI.Business.MappingProfiles;
using WebAPI.Business.Validator;
using WebAPI.Repository.Core;
using WebAPI.Repository.Implementation;

namespace WebAPI.Extensions
{
    /// <summary>
    /// Dependency Injection Extensions
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add dependencies to DI container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductDomain, ProductDomain>();
            services.AddScoped<ICommandText, CommandText>();
            services.AddScoped<IDapperRepositoryBase, DapperRepositoryBase>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(typeof(ProfileMappings));
            services.AddLogging();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>());
            return services;
        }
    }
}
