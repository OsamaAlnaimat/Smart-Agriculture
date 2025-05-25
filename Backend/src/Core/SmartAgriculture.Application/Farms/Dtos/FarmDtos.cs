using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.Weather.Dtos;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Dtos
{
    public class FarmDtos
    {
        public int Id { get; set; }
        public String? FarmName { get; set; }
        public double FarmSize { get; set; }
        public string? FramLocation { get; set; }
        public double OverAllStatus { get; set; }

        public List<WeatherDto>? WeatherReadings { get; set; } = [];
        public List<FieldDto>? Fields { get; set; } = [];
    }
}
