using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStoreWeb.Models_View;

namespace WebStoreWeb.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Review, ReviewModel>().ReverseMap();
            CreateMap<ProductBlob, ProductBlobModel>().ReverseMap();
            CreateMap<Product, OrderProduct>();
        }
    }
}