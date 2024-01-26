using Admin.DTOs;
using Admin.Models;
using AutoMapper;

namespace Admin
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
