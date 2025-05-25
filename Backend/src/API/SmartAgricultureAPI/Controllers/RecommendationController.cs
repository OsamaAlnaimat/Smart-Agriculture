using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Recommendations.Queries.GetRecommendationForField;
using SmartAgriculture.Application.SoildData.Commands.RecordSoildData;
using SmartAgriculture.Application.SoildData.Queries.GetSoilDataForField;
using SmartAgriculture.Domain.Constants;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/farm/{farmId}/fields/{fieldId}/Recommendation")]
    [Authorize(Roles = UserRoles.Farmer)]
    public class RecommendationController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRecommendationForField([FromRoute] int farmId, [FromRoute] int fieldId)
        {
            var Recommendation = await mediator.Send(new GetRecommendationForFieldQuery(farmId, fieldId));
            return Ok(Recommendation);
        }
    }
}
