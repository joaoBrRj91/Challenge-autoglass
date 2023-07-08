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

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductGetAllDto>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, AddSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();

        }
    }
}

