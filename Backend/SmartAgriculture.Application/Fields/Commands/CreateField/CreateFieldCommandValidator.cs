using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Fields.Commands.CreateField
{
    internal class CreateFieldCommandValidator : AbstractValidator<CreateFieldCommand>
    {
        public CreateFieldCommandValidator()
        {
            RuleFor(x => x.FieldName)
                .NotEmpty().WithMessage("Field name is required")
                .MaximumLength(100).WithMessage("Field name must not exceed 100 characters");

            RuleFor(x => x.FieldSize)
                .GreaterThan(0).WithMessage("Field size must be greater than 0");

            RuleFor(x => x.CropType)
                .NotEmpty().WithMessage("Crop type is required");
        }
    }
}
