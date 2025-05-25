using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.SoildData.Commands.RecordSoildData
{
    public class RecordSoilDataCommandValidator : AbstractValidator<RecordSoilDataCommand>
    {
        public RecordSoilDataCommandValidator()
        {
            RuleFor(x => x.SoilPH)
                .InclusiveBetween(0, 14).WithMessage("Soil pH must be between 0 and 14.");

            RuleFor(x => x.Nitrogen)
                .GreaterThanOrEqualTo(0).WithMessage("Nitrogen value must be non-negative.");

            RuleFor(x => x.Phosphorus)
                .GreaterThanOrEqualTo(0).WithMessage("Phosphorus value must be non-negative.");

            RuleFor(x => x.Potassium)
                .GreaterThanOrEqualTo(0).WithMessage("Potassium value must be non-negative.");

            RuleFor(x => x.SoilTexture)
                .MaximumLength(100).WithMessage("Soil texture must be 100 characters or fewer.")
                .When(x => !string.IsNullOrEmpty(x.SoilTexture));

            RuleFor(x => x.SoilMoisture)
                .InclusiveBetween(0, 100).WithMessage("Soil moisture should be between 0% and 100%.");

            RuleFor(x => x.SoilOrganicMatter)
                .GreaterThanOrEqualTo(0).WithMessage("Soil organic matter must be non-negative.");
        }
    }
}
