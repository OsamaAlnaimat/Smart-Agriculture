using SmartAgriculture.Application.SoildData.Dtos;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Dtos
{
    public class FieldDto
    {
        public int Id { get; set; }
        public string? FieldName { get; set; }
        public double FieldSize { get; set; }
        public string? CropType { get; set; }

        public SoilCondition FieldCondition { get; set; }


        public SoilDataDto? soilData { get; set; }
        public List<Recommendation>? recommendation { get; set; } = [];
        
    }
}
