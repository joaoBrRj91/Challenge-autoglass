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

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Supplier, ResultSupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierGetDto>().ReverseMap();
            CreateMap<Supplier, AddSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();

        }
    }
}

