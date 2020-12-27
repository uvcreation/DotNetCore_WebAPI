using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Business.Core;
using WebAPI.Business.Implementation;
using WebAPI.Business.MappingProfiles;
using WebAPI.Repository.Core;
using WebAPI.Repository.Implementation;

namespace WebAPI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductDomain, ProductDomain>();
            services.AddScoped<ICommandText, CommandText>();
            services.AddScoped<IDapperRepositoryBase, DapperRepositoryBase>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(typeof(ProfileMappings));
            return services;
        }
    }
}
