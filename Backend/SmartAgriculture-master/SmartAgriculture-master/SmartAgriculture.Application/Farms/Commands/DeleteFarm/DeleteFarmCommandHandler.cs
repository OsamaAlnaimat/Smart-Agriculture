using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.DeleteFarm
{
    public class DeleteFarmCommandHandler(ILogger<DeleteFarmCommandHandler> logger,
        IFarmRepository farmsRepository) : IRequestHandler<DeleteFarmCommand>
    {
        public async Task Handle(DeleteFarmCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting farm with {FarmId}",request.Id);
            var farm = await farmsRepository.GetByIdAsync(request.Id);
            if (farm == null)
                throw new NotFoundException(nameof(Farm),request.Id.ToString());

            await farmsRepository.Delete(farm);
        }
    }
}
