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

namespace SmartAgriculture.Application.Fields.Commands.DeleteField
{
    public class DeleteFieldForFarmCommandHandler(ILogger<DeleteFieldForFarmCommandHandler> logger,
        IFarmRepository farmRepository,
        IUserContext userContext,
        IFieldsRepository fieldsRepository) : IRequestHandler<DeleteFieldForFarmCommand>
    {
        public async Task Handle(DeleteFieldForFarmCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            logger.LogWarning("Retrieving field: {fieldId}, for farm with id: {farmId}",
             request.FieldId,
             request.FarmId);
            var farm = await farmRepository.GetByIdAsync(request.FarmId,user!.Id);
            if (farm == null) throw new NotFoundException(nameof(Farm), request.FarmId.ToString());

            var field = farm.Fields?.FirstOrDefault(f => f.Id == request.FieldId);
            if (field == null) throw new NotFoundException(nameof(Field), request.FieldId.ToString());

            await fieldsRepository.Delete(field);

        }
    }
}
