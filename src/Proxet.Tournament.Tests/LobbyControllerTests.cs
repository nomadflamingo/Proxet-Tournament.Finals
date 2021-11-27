using Moq;
using Proxet.Tournament.API.Controllers;
using Proxet.Tournament.API.Data;
using Proxet.Tournament.API.Dtos;
using Proxet.Tournament.API.Models;
using Proxet.Tournament.API.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Proxet.Tournament.Tests
{
    public class LobbyControllerTests
    {
        private readonly Mock<ILobbyRepository> repositoryStub = new();
        private readonly Mock<AppDbContext> dbStub = new();

        private Player CreateRandomPlayer()
        {
            return new Player
            {
                Id = 1,
                Name = Guid.NewGuid().ToString(),
                VehicleType = 2,
            };
        }

        [Fact]
        public async Task ItShouldAddPlayerToLobby()
        {
            // Arrange
            Player playerToAdd = CreateRandomPlayer();
            repositoryStub.Setup(repo => repo.AddPlayerAsync(playerToAdd));

            var controller = new LobbyController(repositoryStub.Object, dbStub.Object);

            var playerDto = new PlayerDto() { Name = playerToAdd.Name, VehicleType = playerToAdd.VehicleType };

            // Act
            await controller.AddPlayerAsync(playerDto);

            // Assert
        }
    }
}
