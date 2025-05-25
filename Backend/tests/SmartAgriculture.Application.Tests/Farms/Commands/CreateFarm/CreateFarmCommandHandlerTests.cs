using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using Xunit;

namespace SmartAgriculture.Application.Farms.Commands.CreateFarm.Tests;

public class CreateFarmCommandHandlerTests
{
    [Fact()]
    public async Task Handle_ForValidCommand_ReturnsCreateFarmId()
    {
        //arrange
        var loggerMock = new Mock<ILogger<CreateFarmCommandHandler>>();
        var mapperMock = new Mock<IMapper>();

        var command = new CreateFarmCommand();
        var farm = new Farm();

        mapperMock
            .Setup(x => x.Map<Farm>(It.IsAny<CreateFarmCommand>()))
            .Returns(farm);


        var farmrepositoryMock = new Mock<IFarmRepository>();
        farmrepositoryMock
            .Setup(x => x.Create(It.IsAny<Farm>()))
            .ReturnsAsync(1);

        var userContextMock = new Mock<IUserContext>();
        var currentUser = new CurrentUser("owner-id", "test@test.com", []);
        userContextMock.Setup(u => u.GetCurrentUser()).Returns(currentUser);


        var commnadHandler = new CreateFarmCommandHandler(loggerMock.Object,
            mapperMock.Object,  
            userContextMock.Object,
            farmrepositoryMock.Object);

        //act
        var result = await commnadHandler.Handle(command, CancellationToken.None);


        //assert
        result.Should().Be(1);
        farm.FarmerId.Should().Be("owner-id");
        farmrepositoryMock.Verify(x => x.Create(farm), Times.Once);
    }
}