using MediatR;
using SmartAgriculture.Application.ChatBot.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.ChatBot.Queries
{
    public class GetChatBotResponseQuery(string userInput): IRequest<chatMessageDto>
    {
        public string UserInput { get; set; } = userInput;
    }
}
