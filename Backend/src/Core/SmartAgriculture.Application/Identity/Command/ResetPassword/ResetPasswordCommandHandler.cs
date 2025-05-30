using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Identity.Command.ResetPassword
{
    public class ResetPasswordCommandHandler(UserManager<User> _userManager) : IRequestHandler<ResetPasswordCommand,bool>
    {
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
          
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("User not found.");

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                var errorMessages = string.Join(" | ", result.Errors.Select(e => e.Description));
                throw new Exception($"Password reset failed: {errorMessages}");
            }

            return true;
        }
    }
}
