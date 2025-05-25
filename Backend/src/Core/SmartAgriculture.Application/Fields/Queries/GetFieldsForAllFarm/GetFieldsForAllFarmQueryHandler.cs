using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Fields.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;

namespace SmartAgriculture.Application.Fields.Queries.GetFieldsForAllFarm;

public class GetFieldsForAllFarmQueryHandler(ILogger<GetFieldsForAllFarmQueryHandler> logger,
      IFarmRepository farmsRepository,
      IUserContext userContext,
        IMapper mapper) : IRequestHandler<GetFieldsForAllFarmQuery, IEnumerable<FieldDto>>
{
    public async Task<IEnumerable<FieldDto>> Handle(GetFieldsForAllFarmQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Retrieving fields for farm with id: {farmId}",request.FarmId);
        var farm = await farmsRepository.GetByIdAsync(request.FarmId,user!.Id);

        if (farm == null) throw new NotFoundException(nameof(Farm),request.FarmId.ToString());

        var result = mapper.Map<IEnumerable<FieldDto>>(farm.Fields);

        return result;
    }
}
