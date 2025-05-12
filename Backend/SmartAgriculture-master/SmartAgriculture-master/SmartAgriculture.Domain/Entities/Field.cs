using SmartAgriculture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string? FieldName { get; set; }
        public double FieldSize { get; set; }
        public string? CropType { get; set; }

        public SoilCondition FieldCondition { get; set; }


        public SoilData? soilData { get; set; } 
        public Recommendation? recommendation { get; set; }
        

        public int FarmId { get; set; }
        public Farm? Farm { get; set; }
    }
}
