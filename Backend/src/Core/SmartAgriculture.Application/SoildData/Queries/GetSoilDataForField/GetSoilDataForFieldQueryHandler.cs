using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm;
using SmartAgriculture.Application.SoildData.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Queries.GetSoilDataForField
{
    public class GetSoilDataForFieldQueryHandler(ILogger<GetSoilDataForFieldQueryHandler> logger,
      IFarmRepository farmsRepository,
      ISoilDataRepository soilDataRepository,
      IUserContext userContext,
        IMapper mapper) : IRequestHandler<GetSoilDataForFieldQuery, SoilDataDto>
    {
        public async Task<SoilDataDto> Handle(GetSoilDataForFieldQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Retrieving soilData for farm with id: {farmId} " +
                "and field with id: {field} ", request.FarmId,request.FieldId);

            var farm = await farmsRepository.GetByIdAsync(request.FarmId,user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = farm.Fields?.FirstOrDefault(f => f.Id == request.FieldId);
            if (field == null) throw new NotFoundException(nameof(Field), request.FieldId.ToString());

            var soilData = field.soilData;
            if (soilData == null) throw new NotFoundException(nameof(soilData), request.FieldId.ToString());

            var result = mapper.Map<SoilDataDto>(soilData);

            return result;
        }
    }
}
