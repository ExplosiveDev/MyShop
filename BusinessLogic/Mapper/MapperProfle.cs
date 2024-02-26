using BusinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public class MapperProfle : AutoMapper.Profile
    {
        public MapperProfle()
        {
            CreateMap<Product, ProductDTO>().ForMember(dto => dto.CategoryName, opt => opt.MapFrom(o => o.Category!.Name)).ReverseMap();
            CreateMap<CategoryDTO, Category>().ForMember(opt => opt.Products, dto => dto.Ignore()).ReverseMap();
            CreateMap<Basket, BasketDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Product, ProductInBasket>().ForMember(basket => basket.ProductId, prod => prod.MapFrom(x => x.Id))
                .ForMember(basket => basket.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
