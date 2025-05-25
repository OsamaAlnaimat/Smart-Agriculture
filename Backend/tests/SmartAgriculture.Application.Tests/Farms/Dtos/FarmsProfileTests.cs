using AutoMapper;
using FluentAssertions;
using SmartAgriculture.Application.Farms.Commands.CreateFarm;
using SmartAgriculture.Application.Farms.Commands.UpdateFarm;
using SmartAgriculture.Domain.Entities;
using Xunit;

namespace SmartAgriculture.Application.Farms.Dtos.Tests;

public class FarmsProfileTests
{
    private IMapper mapper;
    public FarmsProfileTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<FarmsProfile>());

        mapper = config.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForFarmToFarmDto_MapsCorretly()
    {
        //arrange
        var farm = new Farm
        {
            Id = 1,
            FarmName = "Test Farm",
            FarmSize = 100,
            FramLocation = "Test Location"
        };

        //act
        var farmDto = mapper.Map<FarmDtos>(farm);


        //assert
        farmDto.Should().NotBeNull();
        farmDto.Id.Should().Be(farm.Id);
        farmDto.FarmName.Should().Be(farm.FarmName);
        farmDto.FarmSize.Should().Be(farm.FarmSize);
        farmDto.FramLocation.Should().Be(farm.FramLocation);
    }

    [Fact()]
    public void CreateMap_ForCreateFarmCommandToFarm_MapsCorretly()
    {
        //arrange
        var command = new CreateFarmCommand
        {
            FarmName = "Test Farm",
            FarmSize = 100,
            FramLocation = "Test Location"
        };


        //act
        var farm = mapper.Map<Farm>(command);


        //assert
        farm.Should().NotBeNull();
        farm.FarmName.Should().Be(command.FarmName);
        farm.FarmSize.Should().Be(command.FarmSize);
        farm.FramLocation.Should().Be(command.FramLocation);

        
    }


    [Fact()]
    public void CreateMap_ForUpdateFarmCommandToFarm_MapsCorretly()
    {
        //arrange
        var command = new UpdateFarmCommand
        {
            Id = 1,
            FarmName = "update Farm",
            FarmSize = 100,
            FramLocation = "update Location"
        };


        //act
        var farm = mapper.Map<Farm>(command);


        //assert
        farm.Should().NotBeNull();
        farm.Id.Should().Be(command.Id);
        farm.FarmName.Should().Be(command.FarmName);
        farm.FarmSize.Should().Be(command.FarmSize);
        farm.FramLocation.Should().Be(command.FramLocation);
    }
}
