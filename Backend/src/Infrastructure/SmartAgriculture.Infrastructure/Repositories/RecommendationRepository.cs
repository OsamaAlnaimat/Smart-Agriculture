using Azure.Core;
using Newtonsoft.Json;
using RestSharp;
using SmartAgriculture.Application.Recommendations.Models;
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
    internal class RecommendationRepository(SmartAgriDbContext dbContext) : IRecommendationRepository
    {
        public async Task<string?> FetchRecommendationAsync(SoilData soilData, WeatherData weatherData, int fieldId, string userId)
        {
            //var recommendationRequest = new RecommendationRequest()
            //{
            //    SoilPH = soilData.SoilPH,
            //    Nitrogen = soilData.Nitrogen,
            //    Phosphorus = soilData.Phosphorus,
            //    Potassium = soilData.Potassium,
            //    SoilTexture = soilData.SoilTexture!,
            //    SoilMoisture = soilData.SoilMoisture,
            //    SoilOrganicMatter = soilData.SoilOrganicMatter,
            //    Temperature = weatherData.Temperature,
            //    Precipition = weatherData.Precipition,
            //    Humidity = weatherData.Humidity,
            //    WindSpeed = weatherData.WindSpeed
            //};

            var apiUrl = $"http://0.0.0.0:5000/api/chat?user_id={userId}&top_k=3&score_threshold=0.7";

            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");

           var queryText = 
                $"[SoilData] " +
                $"Soil PH: {soilData.SoilPH}, " +
                $"Nitrogen: {soilData.Nitrogen}, " +
                $"Phosphorus: {soilData.Phosphorus}, " +
                $"Potassium: {soilData.Potassium}, " +
                $"Soil Texture: {soilData.SoilTexture}, " +
                $"Soil Moisture: {soilData.SoilMoisture}, " +
                $"Organic Matter: {soilData.SoilOrganicMatter}. " +

                $"[WeatherData] " +
                $"Temperature: {weatherData.Temperature}, " +
                $"Humidity: {weatherData.Humidity}, " +
                $"Wind Speed: {weatherData.WindSpeed}, " +
                $"Precipitation: {weatherData.Precipition}";


            var body = new
            {
                query = queryText
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)        
                return response.Content;
            
            return null;
        }
    }
}