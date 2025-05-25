using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class SoilData
    {
        public int Id { get; set; }   
        public double SoilPH { get; set; } 
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string? SoilTexture { get; set; } 
        public double SoilMoisture { get; set; }
        public double SoilOrganicMatter { get; set; }

        public DateTime CollectedAt { get; set; } = DateTime.Now;

        public int FieldId { get; set; }
        public Field? Field { get; set; } 
    }
}
