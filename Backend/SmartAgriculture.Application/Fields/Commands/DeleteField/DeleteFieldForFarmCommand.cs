using MediatR;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Commands.DeleteField
{
    public class DeleteFieldForFarmCommand(int farmId,int fieldId) : IRequest
    {
        public int FarmId { get; set; } = farmId;
        public int FieldId { get; set; } = fieldId;
    }
}
