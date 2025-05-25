using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Farms.Queries.GetAllFarms;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.CreateFarm
{
    public class CreateFarmCommandHandler(ILogger<CreateFarmCommandHandler> logger,
        IMapper mapper,
        IUserContext userContext,
        IFarmRepository farmsRepository) : IRequestHandler<CreateFarmCommand, int>
    {
        public async Task<int> Handle(CreateFarmCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            logger.LogInformation("{UserEmail} [{UserId}] is Creating a new Farm {@farm}",
                currentUser!.Email,
                currentUser.Id,
                request);

            var farm = mapper.Map<Farm> (request);
            farm.FarmerId = currentUser!.Id;

            int id = await farmsRepository.Create(farm);
            return id;
        }   
    }
}
