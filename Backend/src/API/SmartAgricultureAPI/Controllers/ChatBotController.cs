using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartAgriculture.Application.ChatBot.Queries;

namespace SmartAgricultureAPI.Controllers
{
    [ApiController]
    [Route("api/chatbot")]
    public class ChatBotController(IMediator mediator) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetResponse(string userInput)
        {
            var response = await mediator.Send(new GetChatBotResponseQuery(userInput));
            return Ok(response);
        }
    }
}
