using AutoMapper;
using MediatR;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using OllamaSharp;
using OllamaSharp.Models;
using SmartAgriculture.Application.ChatBot.Dtos;
using SmartAgriculture.Application.Farms.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.ChatBot.Queries
{
  
    public class GetChatBotResponseQueryHandler(ILogger<GetChatBotResponseQueryHandler> logger,
        IUserContext userContext,
        IChatRepository chatRepository,
        IMapper mapper) : IRequestHandler<GetChatBotResponseQuery, chatMessageDto>
    {
        public async Task<chatMessageDto> Handle(GetChatBotResponseQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Generating OpenAI response for user with id: {userId}",user!.Id);

            var ResponseMessage = await chatRepository.GenerateAndStoreResponseAsync(request.UserInput,user.Id);

            if (ResponseMessage == null)
            {
                throw new Exception("Failed to generate response from OpenAI.");
            }

            var chatMessageDto = mapper.Map<chatMessageDto>(ResponseMessage);

            return chatMessageDto;
        }
    }
}
