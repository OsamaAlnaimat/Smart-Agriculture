using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
