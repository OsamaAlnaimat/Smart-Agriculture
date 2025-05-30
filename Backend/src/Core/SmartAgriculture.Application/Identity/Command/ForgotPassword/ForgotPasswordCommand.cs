using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Identity.Command.ForgotPassword
{
    public class ForgotPasswordCommand(string email) : IRequest<bool>
    {
        public string Email { get; set; } = email;
    }

}
