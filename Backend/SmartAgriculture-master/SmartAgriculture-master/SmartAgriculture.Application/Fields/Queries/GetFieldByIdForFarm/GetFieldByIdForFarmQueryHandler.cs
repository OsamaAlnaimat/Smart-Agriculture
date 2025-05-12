using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Queries.GetFieldByIdForFarm
{
    public class GetFieldByIdForFarmQueryHandler(ILogger<GetFieldsForAllFarmQueryHandler> logger,
      IFarmRepository farmsRepository,
        IMapper mapper) : IRequestHandler<GetFieldByIdForFarmQuery, FieldDto>
    {
        public async Task<FieldDto> Handle(GetFieldByIdForFarmQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving field: {fieldId}, for farm with id: {farmId}", 
                request.FieldId,
                request.FarmId);

            var farm = await farmsRepository.GetByIdAsync(request.FarmId);

            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = farm.Fields?.FirstOrDefault(f => f.Id == request.FieldId);
            if(field == null) throw new NotFoundException(nameof(Field), request.FieldId.ToString());

            var result = mapper.Map<FieldDto>(field);
            return result;
        }
    }
}
