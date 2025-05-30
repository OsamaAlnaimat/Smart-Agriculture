using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Identity.Command.ResetPassword
{
    public class ResetPasswordCommand(string email, string token, string NewPassword) : IRequest<bool>
    {
        public string Email { get; set; }  = email;
        public string Token { get; set; } = token;
        public string NewPassword { get; set; } = NewPassword;
    }
}
