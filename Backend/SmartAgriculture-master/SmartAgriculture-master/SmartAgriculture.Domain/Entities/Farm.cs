using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class Farm
    {
        public int Id { get; set; }
        public String? FarmName { get; set; }
        public double FarmSize { get; set; }
        public string? FramLocation { get; set; }
        public double OverAllStatus { get; set; }

        public List<WeatherData>? WeatherReadings { get; set; }
        public List<Field>? Fields { get; set; }

        public User Farmer { get; set; } = default!;

        public string FarmerId { get; set; } = default!;

    }
}
