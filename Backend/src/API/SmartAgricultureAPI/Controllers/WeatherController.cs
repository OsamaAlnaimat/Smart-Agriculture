using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Weather.Queries;
using SmartAgriculture.Domain.Constants;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/farm/{farmId}/weather/")]
    [Authorize(Roles = UserRoles.Farmer)]
    public class WeatherController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FetchWeather([FromRoute] int farmId, [FromQuery] string city)
        {
            var result = await mediator.Send(new GetWeatherQuery(city, farmId));
            return Ok(result);
        }
    }
}
