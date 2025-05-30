using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class Recommendation
    {
   
        public int Id { get; set; }

        public string parameter { get; set; } = default!;
        public string value { get; set; } = default!;
        public string status { get; set; } = default!;
        public string advice { get; set; } = default!;

        public DateTime GeneratedAt { get; set; } = DateTime.Now;

        public int FieldId { get; set; } 
        public Field? Field { get; set; } 
    }
}
