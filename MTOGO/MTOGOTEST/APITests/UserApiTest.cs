using Microsoft.AspNetCore.Mvc;
using Moq;
using MTOGO.Api;
using MTOGO.DTOs.UserDTO;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGOTEST.APITests
{
    public class UserApiTests
    {
        private readonly Mock<IFacadeFactory> _mockFacadeFactory;
        private readonly Mock<IUserInterface> _mockUserFacade;
        private readonly UserApi _controller;

        public UserApiTests()
        {
            _mockFacadeFactory = new Mock<IFacadeFactory>();
            _mockUserFacade = new Mock<IUserInterface>();

            // Setup the factory to return the mocked user facade
            _mockFacadeFactory.Setup(f => f.GetUserFacade()).Returns(_mockUserFacade.Object);

            // Instantiate the controller with the mocked factory
            _controller = new UserApi(_mockFacadeFactory.Object);
        }

        [Fact]
        public async Task CreateUser_ReturnsOkResult_WithCreatedUser()
        {
            // Arrange
            var userDto = new UserDTO { Id = 1, Email = "test@example.com", Password = "Password123" };
            _mockUserFacade
                .Setup(facade => facade.CreateUserAsync(It.IsAny<UserDTO>()))
                .ReturnsAsync(userDto);

            // Act
            var result = await _controller.CreateUser(userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(userDto.Id, returnUser.Id);
            Assert.Equal(userDto.Email, returnUser.Email);
        }

        
        [Fact]
        public async Task Login_ReturnsOkResult_WithLoggedInUser()
        {
            // Arrange
            var userDto = new UserDTO { Id = 1, Email = "login@example.com", Password = "Password123" };
            _mockUserFacade
                .Setup(facade => facade.LoginUserAsync(It.IsAny<UserDTO>()))
                .ReturnsAsync(userDto);

            // Act
            var result = await _controller.Login(userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(userDto.Id, returnUser.Id);
            Assert.Equal(userDto.Email, returnUser.Email);
        }

    
    }
}
