using System;
using AutoMapper;
using ChallengeAutoGlass.Application.Dtos;
using ClallangeAutoGlass.Business.Entities;

namespace ChallengeAutoGlass.Application.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Supplier, SuppliersDto>().ReverseMap();
            CreateMap<Product, ProductsDto>().ReverseMap();

        }
    }
}

