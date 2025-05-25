using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandHandler(ILogger<CreateFieldCommandHandler> logger,
        IMapper mapper,
        IFieldsRepository fieldsRepository,
        IUserContext userContext,
        IFarmRepository farmsRepository
       ) : IRequestHandler<CreateFieldCommand,int>
    {
        public async Task<int> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Creating a new Field {@field}", request);
            var farm = await farmsRepository.GetByIdAsync(request.FarmId,user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = mapper.Map<Field>(request);

            return await fieldsRepository.Create(field);
        }
    }
}
