using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Dtos
{
    public class SoilDataDto
    {
        public int Id { get; set; }
        public double SoilPH { get; set; }
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string? SoilTexture { get; set; }
        public double SoilMoisture { get; set; }
        public double SoilOrganicMatter { get; set; }

   
    }
}
