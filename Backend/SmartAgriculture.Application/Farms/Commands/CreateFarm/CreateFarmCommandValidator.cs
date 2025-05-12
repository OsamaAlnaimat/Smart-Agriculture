using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Farms.Commands.CreateFarm
{
    public class CreateFarmCommandValidator : AbstractValidator<CreateFarmCommand>
    {
        public CreateFarmCommandValidator()
        {
            RuleFor(f => f.FarmName)
            .NotEmpty().WithMessage("Farm name is required.")
            .MaximumLength(100).WithMessage("Farm name cannot exceed 100 characters.");

            RuleFor(f => f.FarmSize)
                .GreaterThan(0).WithMessage("Farm size must be greater than 0.");

            RuleFor(f => f.FramLocation)
                .NotEmpty().WithMessage("Farm location is required.")
                .MaximumLength(100).WithMessage("Farm location cannot exceed 100 characters.");
        }
    }
}
