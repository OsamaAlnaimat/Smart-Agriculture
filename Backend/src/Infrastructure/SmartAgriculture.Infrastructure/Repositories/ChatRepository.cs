using Microsoft.Extensions.Configuration;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using SmartAgriculture.Infrastructure.Persistence;
using OllamaSharp;
using OllamaSharp.Models;
using System.Text;


namespace SmartAgriculture.Infrastructure.Repositories
{
    internal class ChatRepository(
        IConfiguration config,
        SmartAgriDbContext dbContext) : IChatRepository
    {
        private readonly OllamaApiClient _ollamaClient = new("http://localhost:11434");
        public async Task<chatMessage> GenerateAndStoreResponseAsync(string inputMessage,string userId)
        {
            
           
            var request = new GenerateRequest
            {
                Model = "llama2",
                Prompt = inputMessage 
            };

            var responseBuilder = new StringBuilder();

            await foreach (var chunk in _ollamaClient.GenerateAsync(request))
            {
                if (chunk is not null)
                    responseBuilder.Append(chunk.Response);
            }
     
            string fullResponse = responseBuilder.ToString();
      
            var chatmmessage = new chatMessage
            {
                FarmerId = userId,
                Input = inputMessage,
                Response = fullResponse,
            };


            dbContext.Add(chatmmessage);
            await dbContext.SaveChangesAsync();

            return chatmmessage;
        }
    }
}
