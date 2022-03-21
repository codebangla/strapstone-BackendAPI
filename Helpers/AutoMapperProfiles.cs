using API.Dtos;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            //CreateMap<Conference, ConferenceListDto>()
            //    .ForMember(d => d.Speaker, opt => opt.MapFrom(src => src.Speaker.Name));

        }
    }
}
