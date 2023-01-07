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
                ).ReverseMap();
                
            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, option => 
                    option.MapFrom(src => src.Photos.FirstOrDefault(p =>p.IsMain).Url)
                ).ReverseMap();
            CreateMap<Photo, PhotoForDetailsDto>().ReverseMap();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoCreatingDto, Photo>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}