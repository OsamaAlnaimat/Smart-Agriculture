using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public List<Farm> OwnedFarms { get; set; } = [];

        public List<chatMessage> ChatMessages { get; set; } = [];
    }
}
