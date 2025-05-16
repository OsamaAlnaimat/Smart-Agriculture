using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Farms.Queries.GetAllFarms;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.UpdateFarm
{
    public class UpdateFarmCommandHandler(ILogger<GetAllFarmsQueryHandler> logger,
        IMapper mapper,
        IUserContext userContext,
        IFarmRepository farmsRepository) : IRequestHandler<UpdateFarmCommand>
    {
        public async Task Handle(UpdateFarmCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Updating farm with {FarmId} with {@updatefarm}",request.Id,request);
            var farm = await farmsRepository.GetByIdAsync(request.Id,user!.Id);
            if (farm == null)
                throw new NotFoundException(nameof(Farm), request.Id.ToString());

            mapper.Map(request, farm);
            await farmsRepository.SaveChanges();

        }
    }
}
