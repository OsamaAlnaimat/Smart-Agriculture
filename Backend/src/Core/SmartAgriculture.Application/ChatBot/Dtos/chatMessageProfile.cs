using AutoMapper;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.ChatBot.Dtos
{
    public class chatMessageProfile : Profile
    {
        public chatMessageProfile()
        {
            CreateMap<chatMessage, chatMessageDto>();    
        }
    }
}
