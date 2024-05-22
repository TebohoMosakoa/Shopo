using AccountApi.DTOs;
using AccountApi.Models;
using AutoMapper;

namespace AccountApi
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<ProfileDto, AppUser>().ReverseMap();
        }
    }
}
