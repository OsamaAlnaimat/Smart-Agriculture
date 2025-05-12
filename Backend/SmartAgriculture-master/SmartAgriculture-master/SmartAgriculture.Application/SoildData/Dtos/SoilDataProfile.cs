using AutoMapper;
using SmartAgriculture.Application.Fields.Commands.CreateField;
using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.SoildData.Commands.RecordSoildData;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Dtos
{
    internal class SoilDataProfile : Profile
    {
        public SoilDataProfile()
        {
            CreateMap<RecordSoilDataCommand, SoilData>();
            CreateMap<SoilData, SoilDataDto>();
        }
    }
}
