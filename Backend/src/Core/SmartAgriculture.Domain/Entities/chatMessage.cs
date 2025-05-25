using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class chatMessage
    {
        public int Id { get; set; }
        public string Input { get; set; } = default!;
        public string Response { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User Farmer { get; set; } = default!;

        public string FarmerId { get; set; } = default!;
    }

}
