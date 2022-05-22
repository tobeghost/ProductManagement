using AutoMapper;
using PM.Domain.Catalog;
using ProductManagement.API.Models.Product;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProductManagement.API.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductId, m => m.MapFrom(f => f.Id))
                .ForMember(p => p.Currency, m => m.MapFrom(f => f.Currency.CurrencyCode))
                .ForMember(p => p.Categories, m => m.MapFrom(f => f.ProductCategories))
                .PreserveReferences();
        }
    }
}
