using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Recommendations.Models
{
    public class RecommendationRequest
    {
        public double SoilPH { get; set; }
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string SoilTexture { get; set; } = "";
        public double SoilMoisture { get; set; }
        public double SoilOrganicMatter { get; set; }

        public double Temperature { get; set; }
        public double Precipition { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}
