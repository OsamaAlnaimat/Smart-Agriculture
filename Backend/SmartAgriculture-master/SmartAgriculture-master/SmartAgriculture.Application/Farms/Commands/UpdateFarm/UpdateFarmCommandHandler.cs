using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Farms.Queries.GetAllFarms;
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
        IFarmRepository farmsRepository) : IRequestHandler<UpdateFarmCommand>
    {
        public async Task Handle(UpdateFarmCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating farm with {FarmId} with {@updatefarm}",request.Id,request);
            var farm = await farmsRepository.GetByIdAsync(request.Id);
            if (farm == null)
                throw new NotFoundException(nameof(Farm), request.Id.ToString());

            mapper.Map(request, farm);
            await farmsRepository.SaveChanges();

        }
    }
}
