using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using SmartAgriculture.Application.Farms.Commands.UpdateFarm;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using SmartAgriculture.Application.Users;
using SmartAgriculture.Application.Farms.Queries.GetAllFarms;
using SmartAgriculture.Domain.Exceptions;
using SmartAgriculture.Domain.Constants;
using FluentAssertions;

namespace SmartAgriculture.Application.Farms.Commands.UpdateFarm.Tests;

public class UpdateFarmCommandHandlerTests
{
    private readonly Mock<ILogger<GetAllFarmsQueryHandler>> _loggerMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<IUserContext> _userContextMock = new();
    private readonly Mock<IFarmRepository> _farmRepositoryMock = new();

    private readonly UpdateFarmCommandHandler _handler;

    public UpdateFarmCommandHandlerTests()
    {
        _handler = new UpdateFarmCommandHandler(
            _loggerMock.Object,
            _mapperMock.Object,
            _userContextMock.Object,
            _farmRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldUpdateFarm()
    {
        // arrange
        var userId = "1";
        var currentUser = new CurrentUser(userId, "test@test.com", [UserRoles.Admin]);

        var command = new UpdateFarmCommand
        {
            Id = 1,
            FarmName = "Updated Farm",
            FramLocation = "Updated Location"
        };

        var existingFarm = new Farm
        {
            Id = 1,
            FarmName = "Old Farm",
            FramLocation = "Old Location"
        };

        _userContextMock.Setup(x => x.GetCurrentUser())
            .Returns(currentUser);

        _farmRepositoryMock.Setup(x => x.GetByIdAsync(command.Id, userId))
            .ReturnsAsync(existingFarm);


        // act
        await _handler.Handle(command, CancellationToken.None);


        // assert
        _mapperMock.Verify(m => m.Map(command, existingFarm), Times.Once);
        _farmRepositoryMock.Verify(r => r.SaveChanges(), Times.Once);
    }


    [Fact]
    public async Task Handle_WhenFarmNotFound_ShouldThrowNotFoundException()
    {
        // Arrange
        var userId = "1";
        var currentUser = new CurrentUser(userId, "test@test.com", new[] { UserRoles.Admin });

        var farmId = 33;
        var command = new UpdateFarmCommand
        {
            Id = farmId,
        };

        _userContextMock.Setup(x => x.GetCurrentUser())
            .Returns(currentUser);

        _farmRepositoryMock.Setup(x => x.GetByIdAsync(command.Id, userId))
            .ReturnsAsync((Farm?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Farm with id {farmId} doesn't exist");
    }
}
