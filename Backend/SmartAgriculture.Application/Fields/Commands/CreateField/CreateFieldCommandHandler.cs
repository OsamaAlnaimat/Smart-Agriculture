using AutoMapper;
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

namespace SmartAgriculture.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandHandler(ILogger<CreateFieldCommandHandler> logger,
        IMapper mapper,
        IFieldsRepository fieldsRepository,
        IFarmRepository farmsRepository
       ) : IRequestHandler<CreateFieldCommand,int>
    {
        public async Task<int> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new Field {@field}", request);
            var farm = await farmsRepository.GetByIdAsync(request.FarmId);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = mapper.Map<Field>(request);

            return await fieldsRepository.Create(field);
        }
    }
}
