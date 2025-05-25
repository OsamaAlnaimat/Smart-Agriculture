using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Application.Weather.Dtos;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Weather.Queries
{
    public class GetWeatherQueryHandler(ILogger<GetWeatherQuery> logger,
        IWeatherRepository weatherRepository,
        IFarmRepository farmRepository,
        IUserContext userContext,
        IMapper mapper
        ) : IRequestHandler<GetWeatherQuery, WeatherDto>
    {
        public async Task<WeatherDto> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Retrieving WeatherData for farm with id: {farmId}", request.FarmId);

            var farm = await farmRepository.GetByIdAsync(request.FarmId,user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var fetchWeatherData = await weatherRepository.FetchWeatherAsync(request.CityName, request.FarmId);

            var result = mapper.Map<WeatherDto>(fetchWeatherData);

            return result;
        }
    }
}
