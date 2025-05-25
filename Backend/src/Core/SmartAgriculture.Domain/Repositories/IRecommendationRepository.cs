using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Repositories
{
    public interface IRecommendationRepository
    {
        Task<string?> FetchRecommendationAsync(SoilData soilData,WeatherData weatherData,int fieldId,string userId);
    }
}
