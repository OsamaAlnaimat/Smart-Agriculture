using MediatR;
using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.SoildData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Queries.GetSoilDataForField
{
    public class GetSoilDataForFieldQuery(int farmId, int fieldId) : IRequest<SoilDataDto>
    {
        public int FarmId { get; set; } = farmId;
        public int FieldId { get; set; } = fieldId;
    }
}
