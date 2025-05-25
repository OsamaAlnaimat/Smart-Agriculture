using AutoMapper;
using SmartAgriculture.Application.Weather.Models;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Weather.Dtos
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
           
            CreateMap<WeatherApiResponse, WeatherData>()
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Main.Temp))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed))
                .ForMember(dest => dest.Precipition, opt => opt.MapFrom(src => src.Rain != null ? src.Rain.OneHour ?? 0 : 0))
                .ForMember(dest => dest.FarmId, opt => opt.Ignore());

            CreateMap<WeatherDto, WeatherData>();
            CreateMap<WeatherData, WeatherDto>();

            CreateMap<WeatherApiResponse, WeatherData>();
        }
    }
}
