using AutoMapper;
using KometSales.Application.Users.Commands;
using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Domain;

namespace KometSales.Application.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<UpdateUserCommandHandler.Command, UpdateUserModel>();
            CreateMap<CreateUserCommandHandler.Command, CreateUserModel>();
            CreateMap<UserRol, UserRolDto>();
            CreateMap<User, UserDto>()
                .ForMember(d => d.UserRol, opt => opt.MapFrom(s => s.UserRol));

            CreateMap<CreateUserModel, User>();
        }
    }
}
