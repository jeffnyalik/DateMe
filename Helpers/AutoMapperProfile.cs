using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAPI.Dtos;
using DatingAPI.Models;

namespace DatingAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, option => 
                    option.MapFrom(src => src.Photos.FirstOrDefault(p =>p.IsMain).Url)
                )
                .ForMember(dest => dest.Age, option => 
                    option.MapFrom(src => src.DateOfBirth.CalculateAge())
                );
            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, option => 
                    option.MapFrom(src => src.Photos.FirstOrDefault(p =>p.IsMain).Url)
                )
                .ForMember(dest => dest.Age, option => 
                    option.MapFrom(src => src.DateOfBirth.CalculateAge())
                );
            CreateMap<Photo, PhotoForDetailsDto>().ReverseMap();
        }
    }
}