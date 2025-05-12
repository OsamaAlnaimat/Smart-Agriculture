using MediatR;
using SmartAgriculture.Application.Weather.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Weather.Queries
{
    public record GetWeatherQuery(string cityName, int farmId): IRequest<WeatherDto>
    {
        public int FarmId { get; set; } = farmId;
        public string CityName { get; set; } = cityName;
    }
}
