using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.UpdateFarm
{
    public class UpdateFarmCommand : IRequest
    {
        public int Id { get; set; }
        public String? FarmName { get; set; }
        public double FarmSize { get; set; }
        public string? FramLocation { get; set; }
    }
}
