using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Business.Dto;
using WebAPI.Repository.Entities;

namespace WebAPI.Business.MappingProfiles
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
