using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Commands.RecordSoildData
{
    public class RecordSoilDataCommand : IRequest<int>
    {
        public double SoilPH { get; set; }
        public double Nitrogen { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public string? SoilTexture { get; set; }
        public double SoilMoisture { get; set; }
        public double SoilOrganicMatter { get; set; }

        public DateTime CollectedAt { get; set; } = DateTime.Now;

        public int FarmId { get; set; }
        public int FieldId { get; set; }


    }
}
