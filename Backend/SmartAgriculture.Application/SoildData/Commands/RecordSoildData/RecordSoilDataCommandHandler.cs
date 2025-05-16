using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Fields.Commands.CreateField;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Commands.RecordSoildData
{
    public class RecordSoilDataCommandHandler(ILogger<RecordSoilDataCommandHandler> logger,
        IMapper mapper,
        IFarmRepository farmsRepository,
        IUserContext userContext,
        ISoilDataRepository soilDataRepository
        ) : IRequestHandler<RecordSoilDataCommand, int>
    {   
                
        public async Task<int> Handle(RecordSoilDataCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Recording a new SoilData {@soildata}", request);

            var farm = await farmsRepository.GetByIdAsync(request.FarmId,user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = farm.Fields?.FirstOrDefault(f => f.Id == request.FieldId);
            if (field == null) throw new NotFoundException(nameof(Field), request.FieldId.ToString());

            var soildata = mapper.Map<SoilData>(request);

            return await soilDataRepository.Create(soildata);
        }
    }
}

