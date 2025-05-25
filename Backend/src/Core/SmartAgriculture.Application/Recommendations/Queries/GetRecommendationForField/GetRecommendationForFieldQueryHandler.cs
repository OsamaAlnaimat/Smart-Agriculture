using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Recommendations.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Recommendations.Queries.GetRecommendationForField
{
    public class GetRecommendationForFieldQueryHandler(ILogger<GetRecommendationForFieldQueryHandler> logger,
        IRecommendationRepository recommendationRepository,
        IFarmRepository farmsRepository,
        IWeatherRepository weatherRepository,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<GetRecommendationForFieldQuery, RecommendationDto>
    {
        public async Task<RecommendationDto> Handle(GetRecommendationForFieldQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Retrieving Recommendation for field with id: {fieldId} ",request.FieldId);

            var farm = await farmsRepository.GetByIdAsync(request.FarmId, user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = farm.Fields?.FirstOrDefault(f => f.Id == request.FieldId);
            if (field == null) throw new NotFoundException(nameof(Field), request.FieldId.ToString());
            
            var soilData = field.soilData;
            if (soilData == null) throw new NotFoundException(nameof(SoilData), "Field"+request.FieldId.ToString());

            var getweatherData = await weatherRepository.GetLastReadingForWeatherAsync(request.FarmId);
            if (getweatherData == null) throw new NotFoundException(nameof(Weather), "Farm"+request.FarmId.ToString());
   
            var fetchRecommendation = await recommendationRepository.FetchRecommendationAsync(soilData,getweatherData, request.FieldId, user!.Id);


            return null;
        }
    }
}
