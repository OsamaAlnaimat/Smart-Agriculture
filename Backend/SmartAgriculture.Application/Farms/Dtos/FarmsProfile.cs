using AutoMapper;
using SmartAgriculture.Application.Farms.Commands.CreateFarm;
using SmartAgriculture.Application.Farms.Commands.UpdateFarm;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Dtos
{
    public class FarmsProfile : Profile
    {
        public FarmsProfile() 
        {
            CreateMap<Farm, FarmDtos>();

            CreateMap<CreateFarmCommand,Farm>();

            CreateMap<UpdateFarmCommand,Farm>();
        }

    }
}
