using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Farms.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Queries.GetFarmById
{
    public class GetFarmByIdQueryHandler(ILogger<GetFarmByIdQueryHandler> logger,
        IFarmRepository farmsRepository,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<GetFarmByIdQuery, FarmDtos>
    {
        public async Task<FarmDtos> Handle(GetFarmByIdQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Getting Farm {FarmId} ",request.Id);
            var farm = await farmsRepository.GetByIdAsync( request.Id,user!.Id)
                ?? throw new NotFoundException(nameof(Farm), request.Id.ToString());

            var farmDto = mapper.Map<FarmDtos>( farm );

            return farmDto;
                
        }
    }
}
