using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.Users.Commands.AssignUserRole;
using SmartAgriculture.Application.Users.Commands.RegisterUser;
using SmartAgriculture.Application.Users.Commands.UpdateUserDetails;
using SmartAgriculture.Domain.Constants;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize(Roles = UserRoles.Farmer)]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        } 
        
        [HttpPost("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("RegisterNewFarmer")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {

            await mediator.Send(command);
            return NoContent();
        }
    }
}
