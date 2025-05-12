using FluentValidation;

namespace SmartAgriculture.Application.Farms.Commands.UpdateFarm
{
    public class UpdateFarmCommandValidator : AbstractValidator<UpdateFarmCommand>
    {
        public UpdateFarmCommandValidator() 
        {
            RuleFor(f => f.FarmName)
                .NotEmpty().WithMessage("Farm name is required.")
                .Length(3,100).WithMessage("Farm name cannot exceed 100 characters.");

            RuleFor(f => f.FarmSize)
                .GreaterThan(0).WithMessage("Farm size must be greater than 0.");

            RuleFor(f => f.FramLocation)
                .NotEmpty().WithMessage("Farm name is required.")
                .MaximumLength(100).WithMessage("Farm location cannot exceed 100 characters.");
        }

    }
}
