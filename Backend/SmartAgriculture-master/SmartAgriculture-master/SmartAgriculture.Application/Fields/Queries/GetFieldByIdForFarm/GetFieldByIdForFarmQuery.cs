using MediatR;
using SmartAgriculture.Application.Fields.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Queries.GetFieldByIdForFarm
{
    public class GetFieldByIdForFarmQuery(int farmId, int fieldId) : IRequest<FieldDto>
    {
        public int FarmId { get; } = farmId;
        public int FieldId { get; } = fieldId;
    }
}
