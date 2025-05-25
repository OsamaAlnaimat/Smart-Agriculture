using AutoMapper;
using SmartAgriculture.Application.Fields.Commands.CreateField;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Dtos
{
    public class FieldsProfile : Profile
    {   
        public FieldsProfile()
        {
            CreateMap<CreateFieldCommand, Field>();
            CreateMap<Field, FieldDto>();
        }
    }
}
