using MediatR;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Commands.CreateField;

public class CreateFieldCommand : IRequest<int>
{
    public string? FieldName { get; set; }
    public double FieldSize { get; set; }
    public string? CropType { get; set; }

    public int FarmId { get; set; }
}
