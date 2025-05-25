using FluentValidation.TestHelper;
using Xunit;

namespace SmartAgriculture.Application.Farms.Commands.CreateFarm.Tests;

public class CreateFarmCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        // arange
        var command = new CreateFarmCommand
        {
            FarmName = "Test Farm",
            FarmSize = 10,
            FramLocation = "Test Location"
        };

        var validator = new CreateFarmCommandValidator();


        // act
        var result = validator.TestValidate(command);


        // assert
        result.ShouldNotHaveAnyValidationErrors();
    } 
    
    [Fact()]
    public void Validator_ForInValidCommand_ShouldHaveValidationErrors()
    {
        // arange

        var command = new CreateFarmCommand
        {
            FarmName = "",
            FarmSize = -1,
            FramLocation = ""
        };

        var validator = new CreateFarmCommandValidator();

        // act

        var result = validator.TestValidate(command);

        // assert
        result.ShouldHaveValidationErrorFor(c => c.FarmName);
        result.ShouldHaveValidationErrorFor(c => c.FarmSize);
        result.ShouldHaveValidationErrorFor(c => c.FramLocation);
    }
}