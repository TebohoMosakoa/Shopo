using AutoMapper;
using CatalogApi.DTOs;
using CatalogApi.Models;

namespace CatalogApi
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<BrandDTO, Brand>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
