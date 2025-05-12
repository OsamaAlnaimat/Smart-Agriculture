using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartAgriculture.Application.Weather.Models;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using SmartAgriculture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Infrastructure.Repositories
{
    internal class WeatherRepository(
        IConfiguration config,
        SmartAgriDbContext dbContext
        ) : IWeatherRepository
    {
        public async Task<WeatherData> FetchWeatherAsync(string cityName, int farmId)
        {
            var apiKey = config["Weather:ApiKey"];
            var url = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric");
            var request = new RestRequest("",Method.Get);
            var respons =  url.Execute(request);

            if (respons.IsSuccessful) 
            {
                var weatherResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(respons.Content!);
                var weatherData = new WeatherData
                {
                    FarmId = farmId,
                    Temperature = weatherResponse!.Main.Temp,
                    Humidity = weatherResponse.Main.Humidity,
                    WindSpeed = weatherResponse.Wind.Speed,
                    Precipition = weatherResponse.Rain?.OneHour ?? 0,
                };

                dbContext.Add(weatherData);
                await dbContext.SaveChangesAsync();

                return await GetLastReadingForWeatherAsync(farmId);
            }
            return null;
        }
        public async Task<WeatherData> GetLastReadingForWeatherAsync(int farmId)
        {
            var weatherData = await dbContext.WeatherDatas
                .Where(w => w.FarmId == farmId)
                .OrderByDescending(w => w.CollectedAt)
                .FirstOrDefaultAsync();

            return weatherData!;         
        }
    }
}
