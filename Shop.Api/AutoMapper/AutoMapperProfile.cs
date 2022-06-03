using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace Shop.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, AdminUserDTO>().ReverseMap();
        }
    }
}
