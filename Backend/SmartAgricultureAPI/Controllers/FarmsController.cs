using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Farms.Commands.CreateFarm;
using SmartAgriculture.Application.Farms.Commands.DeleteFarm;
using SmartAgriculture.Application.Farms.Commands.UpdateFarm;
using SmartAgriculture.Application.Farms.Queries.GetAllFarms;
using SmartAgriculture.Application.Farms.Queries.GetFarmById;
using SmartAgriculture.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/farms")]
    [Authorize(Roles = UserRoles.Farmer)]
    public class FarmsController(IMediator mediator) : ControllerBase
    {   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var farms = await mediator.Send(new GetAllFarmsQuery());
            return Ok(farms);
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var farm = await mediator.Send(new GetFarmByIdQuery(id));

            return Ok(farm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarm(CreateFarmCommand command)
        {

            int id = await mediator.Send(command); 
            return CreatedAtAction(nameof(GetById),new { id },null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarm([FromRoute] int id)
        {
           await mediator.Send(new DeleteFarmCommand(id));

            
            return NoContent();
          
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateFarm([FromRoute] int id,UpdateFarmCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            
            return NoContent();
        }
    }
}
