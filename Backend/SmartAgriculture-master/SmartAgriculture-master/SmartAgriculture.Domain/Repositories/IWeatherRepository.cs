using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherData> FetchWeatherAsync(string cityName, int farmId);
        Task<WeatherData> GetLastReadingForWeatherAsync(int farmId);
    }
}
