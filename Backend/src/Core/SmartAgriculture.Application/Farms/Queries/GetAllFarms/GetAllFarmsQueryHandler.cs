using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Farms.Dtos;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Queries.GetAllFarms
{
    public class GetAllFarmsQueryHandler(ILogger<GetAllFarmsQueryHandler> logger,
        IMapper mapper,
        IUserContext userContext,
        IFarmRepository farmsRepository) : IRequestHandler<GetAllFarmsQuery, IEnumerable<FarmDtos>>
    {
        public async Task<IEnumerable<FarmDtos>> Handle(GetAllFarmsQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Getting all farm");
            var farms = await farmsRepository.GetAllAsync(user!.Id);
            var farmsDtos = mapper.Map<IEnumerable<FarmDtos>>(farms);
            return farmsDtos;
        }
    }
}
