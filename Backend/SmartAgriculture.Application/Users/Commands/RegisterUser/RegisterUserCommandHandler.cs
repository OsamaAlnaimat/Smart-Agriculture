using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Users.Commands.RegisterUser
{
    public  class RegisterUserCommandHandler(ILogger<RegisterUserCommandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : IRequestHandler<RegisterUserCommand>
    {
        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("create new user: {@Request}", request);

            var user = new User { 
                UserName = request.Email, 
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth};

            var createResult = await userManager.CreateAsync(user, request.Password);

            var role = await roleManager.FindByNameAsync("Farmer")
                ?? throw new NotFoundException(nameof(User), "Farmer");


           await userManager.AddToRoleAsync(user, "Farmer");
        }
    }

}
