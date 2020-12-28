using AutoMapper;
using WebAPI.Business.Models;
using WebAPI.Repository.Entities;

namespace WebAPI.Business.MappingProfiles
{
    /// <summary>
    /// Register mappings
    /// </summary>
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
