 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Precipition { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }

        public DateTime CollectedAt { get; set; } = DateTime.Now;
        
        public int FarmId { get; set; }
        public Farm? Farm { get; set; }
    }
}
