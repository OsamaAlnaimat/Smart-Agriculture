using MediatR;
using SmartAgriculture.Application.Farms.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Queries.GetAllFarms
{
    public class GetAllFarmsQuery : IRequest<IEnumerable<FarmDtos>>
    {
    }
}
