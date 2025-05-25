using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.DeleteFarm
{
    public class DeleteFarmCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
