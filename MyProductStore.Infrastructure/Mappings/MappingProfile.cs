using AutoMapper;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Core.Entities;

namespace MyProductStore.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain -> Dto
            CreateMap<Product, ProductOutputDto>();
            CreateMap<ProductOutputDto, Product>();

            CreateMap<Product, ProductInputDto>();
            CreateMap<ProductInputDto, Product>();

            CreateMap<RegisterUserCommand, User>();

            CreateMap<User, UserOutputDto>();

            CreateMap<UserInputDto, User>();

        }
    }
}
