using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.ChatBot.Dtos
{
    public class chatMessageDto
    {
        public string Input { get; set; } = default!;
        public string Response { get; set; } = default!;
    }
}
