using AutoMapper;
using MyProductStore.Application.Commands;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Entities;

namespace MyProductStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain -> Dto
            CreateMap<Product, ProductOutputDto>();
            CreateMap<ProductOutputDto, Product>();


            CreateMap<ProductCommand, Product>();
            CreateMap<ProductCommand, ProductInputDto>();

            CreateMap<Product, ProductInputDto>();
            CreateMap<ProductInputDto, Product>();

        }
    }
}
