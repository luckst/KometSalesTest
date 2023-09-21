using AutoMapper;
using KometSales.Application.Products.Commands;
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
            #region Users
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, UpdateUserCommandHandler.Command>();
            CreateMap<CreateUserModel, CreateUserCommandHandler.Command>();
            CreateMap<UserRol, UserRolDto>();
            CreateMap<User, UserDto>()
                .ForMember(d => d.UserRol, opt => opt.MapFrom(s => s.UserRol));
            #endregion

            #region Products
            CreateMap<Product, ProductDto>();
            CreateMap<ProductModel, Product>();
            CreateMap<ProductModel, UpdateProductCommandHandler.Command>();
            CreateMap<ProductModel, CreateProductCommandHandler.Command>();
            #endregion

            #region Customers
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<CustomerModel, UpdateProductCommandHandler.Command>();
            CreateMap<CustomerModel, CreateProductCommandHandler.Command>();
            #endregion
        }
    }
}
