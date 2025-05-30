using AutoMapper;
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
    internal class RecommendationRepository(SmartAgriDbContext dbContext,
        IMapper mapper) : IRecommendationRepository
    {
        public async Task<List<Recommendation>?> FetchRecommendationAsync(SoilData soilData, WeatherData weatherData, int fieldId, string userId)
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


            var mockJson = """
            {
              "status": "success",
              "user_id": "example_user",
              "recommendations": [
                {
                  "parameter": "Soil PH",
                  "value": "6.5",
                  "status": "Optimal",
                  "advice": "Soil pH is in the optimal range (6.0–7.5) for most crops. No immediate pH correction is needed. Maintain pH through regular organic matter addition and periodic soil testing."
                },
                {
                  "parameter": "Nitrogen",
                  "value": "40",
                  "status": "Moderate",
                  "advice": "Nitrogen level is moderately high. Avoid further nitrogen fertilization until next soil test. Monitor plant growth for signs of excess like lush foliage with no flowering."
                },
                {
                  "parameter": "Phosphorus",
                  "value": "25",
                  "status": "Moderate",
                  "advice": "Phosphorus level appears sufficient. Retest if deficiencies are observed. Avoid over-fertilization as excess phosphorus can lead to nutrient lockout."
                },
                {
                  "parameter": "Potassium",
                  "value": "300",
                  "status": "Optimal",
                  "advice": "Potassium level is adequate. Ensure balanced nutrition by combining potassium with other macro and micronutrients as needed."
                },
                {
                  "parameter": "Soil Texture",
                  "value": "Loamy",
                  "status": "Optimal",
                  "advice": "Loamy soil offers excellent balance of drainage and nutrient retention. Continue good management practices like composting and crop rotation."
                },
                {
                  "parameter": "Soil Moisture",
                  "value": "Moderate",
                  "status": "Moderate",
                  "advice": "Soil moisture is within a healthy range. Monitor regularly and use mulching to maintain consistent moisture levels."
                },
                {
                  "parameter": "Organic Matter",
                  "value": "3.2%",
                  "status": "Optimal",
                  "advice": "Organic matter is at a good level. Maintain or increase through composting, cover crops, and reduced tillage practices."
                },
                {
                  "parameter": "Temperature",
                  "value": "22°C",
                  "status": "Optimal",
                  "advice": "Optimal temperature for many crops. Ensure temperature-sensitive plants are protected during fluctuations."
                },
                {
                  "parameter": "Humidity",
                  "value": "60%",
                  "status": "Optimal",
                  "advice": "Humidity is suitable. Monitor for fungal issues in overly humid conditions and ventilate greenhouses if needed."
                },
                {
                  "parameter": "Wind Speed",
                  "value": "15 km/h",
                  "status": "Moderate",
                  "advice": "Wind speed is moderate. No specific action required unless crop lodging or erosion is observed."
                },
                {
                  "parameter": "Precipitation",
                  "value": "5 mm",
                  "status": "Bad",
                  "advice": "Light rainfall. Supplement with irrigation if soil begins to dry out or plants show signs of stress."
                }
              ],
              "cached": false
            }
            """;

           // var apiUrl = $"http://0.0.0.0:5000/api/chat?user_id={userId}&top_k=3&score_threshold=0.7";

           // var client = new RestClient(apiUrl);
           // var request = new RestRequest("", Method.Post);
           // request.AddHeader("Content-Type", "application/json");

           //var queryText = 
           //     $"[SoilData] " +
           //     $"Soil PH: {soilData.SoilPH}, " +
           //     $"Nitrogen: {soilData.Nitrogen}, " +
           //     $"Phosphorus: {soilData.Phosphorus}, " +
           //     $"Potassium: {soilData.Potassium}, " +
           //     $"Soil Texture: {soilData.SoilTexture}, " +
           //     $"Soil Moisture: {soilData.SoilMoisture}, " +
           //     $"Organic Matter: {soilData.SoilOrganicMatter}. " +

           //     $"[WeatherData] " +
           //     $"Temperature: {weatherData.Temperature}, " +
           //     $"Humidity: {weatherData.Humidity}, " +
           //     $"Wind Speed: {weatherData.WindSpeed}, " +
           //     $"Precipitation: {weatherData.Precipition}";


           // var body = new
           // {
           //     query = queryText
           // };

           // var jsonBody = JsonConvert.SerializeObject(body);
           // request.AddStringBody(jsonBody, DataFormat.Json);

           // var response = await client.ExecuteAsync(request);

           // if (response.IsSuccessful)
           // {
                var responseData = JsonConvert.DeserializeObject<RecommendationResponse>(mockJson);

                var recommendations = mapper.Map<List<Recommendation>>(responseData!.recommendations);

                foreach (var recommendation in recommendations)
                    recommendation.FieldId = fieldId;
             
                await dbContext.Recommendations.AddRangeAsync(recommendations);
                await dbContext.SaveChangesAsync();

                return recommendations;
           // }        
               
            //return null;
            
        }
    }
}