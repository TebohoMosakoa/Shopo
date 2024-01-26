using AutoMapper;
using CatalogApi.DTOs;
using CatalogApi.Models;

namespace CatalogApi
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<BrandDTO, Brand>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
