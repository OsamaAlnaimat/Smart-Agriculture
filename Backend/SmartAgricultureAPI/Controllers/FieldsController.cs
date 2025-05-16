using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Fields.Commands.CreateField;
using SmartAgriculture.Application.Fields.Commands.DeleteField;
using SmartAgriculture.Application.Fields.Queries.GetFieldByIdForFarm;
using SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm;
using SmartAgriculture.Domain.Constants;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/farm/{farmId}/fields")]
    [Authorize(Roles = UserRoles.Farmer)]
    public class FieldsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateField([FromRoute]int farmId, CreateFieldCommand command)
        {
            command.FarmId= farmId;
            var fieldId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForFarm), new { farmId ,fieldId},null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForFarm([FromRoute] int farmId)
        {
            var fields = await mediator.Send(new GetFieldsForAllFarmQuery(farmId));
            return Ok(fields);
        } 
        
        [HttpGet("{fieldId}")]
        public async Task<IActionResult> GetByIdForFarm([FromRoute] int farmId, [FromRoute] int fieldId)
        {

            var field = await mediator.Send(new GetFieldByIdForFarmQuery(farmId, fieldId));
            return Ok(field);
        }

        [HttpDelete("{fieldId}")]
        public async Task<IActionResult> DeleteFieldForFarm([FromRoute] int farmId, [FromRoute] int fieldId)
        {
            await mediator.Send(new DeleteFieldForFarmCommand(farmId, fieldId));
            return NoContent();

        }
    }
}
