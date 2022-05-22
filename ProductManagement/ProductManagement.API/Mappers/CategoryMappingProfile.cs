using AutoMapper;
using PM.Domain.Catalog;
using ProductManagement.API.Models.Product;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProductManagement.API.Mappers
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(p => p.CategoryId, m => m.MapFrom(f => f.Id))
                .ForMember(p => p.CategoryName, m => m.MapFrom(f => f.Name));

            CreateMap<ProductCategory, CategoryDto>()
                .ForMember(p => p.CategoryId, m => m.MapFrom(f => f.Category.Id))
                .ForMember(p => p.CategoryName, m => m.MapFrom(f => f.Category.Name));
        }
    }
}
