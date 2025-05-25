using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Fields.Commands.CreateField;
using SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm;
using SmartAgriculture.Application.SoildData.Commands.RecordSoildData;
using SmartAgriculture.Application.SoildData.Queries.GetSoilDataForField;
using SmartAgriculture.Domain.Constants;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/farm/{farmId}/fields/{fieldId}/soildata")]
    [Authorize(Roles = UserRoles.Farmer)]
    public class SoilDataController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSoilDataForField([FromRoute] int farmId, [FromRoute] int fieldId)
        {
            var soilData = await mediator.Send(new GetSoilDataForFieldQuery(farmId, fieldId));
            return Ok(soilData);
        }

        [HttpPost]
        public async Task<IActionResult> RecordSoilData([FromRoute] int farmId, [FromRoute] int fieldId, RecordSoilDataCommand command)
        {
            command.FarmId = farmId;
            command.FieldId = fieldId;

            int soildata = await mediator.Send(command);
            return CreatedAtAction(nameof(GetSoilDataForField), new { farmId, fieldId }, null);
        }
    }
}
