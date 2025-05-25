using MediatR;
using SmartAgriculture.Application.Fields.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm
{
    public class GetFieldsForAllFarmQuery(int farmId) : IRequest<IEnumerable<FieldDto>>
    {
        public int FarmId { get;} = farmId;
    }
}
