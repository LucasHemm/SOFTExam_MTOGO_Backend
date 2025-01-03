using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Moq;
using Moq.Protected;
using MTOGO.DTOs.UserDTO;
using MTOGO.Facades;

namespace MTOGOTEST
{
    public class UserFacadeTests
    {
        [Fact]
        public async Task CreateUserAsync_ShouldReturnUserDTO_OnSuccess()
        {
            // Arrange
            var userToCreate = new UserDTO(0, "newuser@example.com", "newpassword", 1, 0, 0, 0);

            var expectedResponse = new UserDTO(1, "newuser@example.com", "newpassword", 1, 0, 0, 0);


            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery == "/" && req.Method == HttpMethod.Post);

            var userFacade = new UserFacade(httpClient);

            // Act
            var result = await userFacade.CreateUserAsync(userToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Email, result.Email);
            Assert.Equal(expectedResponse.Password, result.Password);
            Assert.Equal(expectedResponse.RestaurantId, result.RestaurantId);
            Assert.Equal(expectedResponse.AgentId, result.AgentId);
            Assert.Equal(expectedResponse.CustomerId, result.CustomerId);
            Assert.Equal(expectedResponse.ManagerId, result.ManagerId);
        }

        [Fact]
        public async Task LoginUserAsync_ShouldReturnUserDTO_OnSuccess()
        {
            // Arrange
            var userToLogin = new UserDTO
            {
                Email = "testuser@example.com",
                Password = "password123"
            };
            var expectedResponse = new UserDTO
            {
                Id = 1,
                Email = "testuser@example.com",
                Password = "password123",
                RestaurantId = 1,
                AgentId = 0,
                CustomerId = 0,
                ManagerId = 0
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse), System.Text.Encoding.UTF8,
                    "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery.EndsWith("login") == true && req.Method == HttpMethod.Post);

            var userFacade = new UserFacade(httpClient);

            // Act
            var result = await userFacade.LoginUserAsync(userToLogin);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Email, result.Email);
            Assert.Equal(expectedResponse.Password, result.Password);
            Assert.Equal(expectedResponse.RestaurantId, result.RestaurantId);
            Assert.Equal(expectedResponse.AgentId, result.AgentId);
            Assert.Equal(expectedResponse.CustomerId, result.CustomerId);
            Assert.Equal(expectedResponse.ManagerId, result.ManagerId);
        }

        [Fact]
        public async Task LoginUserAsync_ShouldThrowException_OnFailure()
        {
            // Arrange
            var userToLogin = new UserDTO
            {
                Email = "invaliduser@example.com",
                Password = "wrongpassword"
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery.EndsWith("login") == true && req.Method == HttpMethod.Post);

            var userFacade = new UserFacade(httpClient);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => userFacade.LoginUserAsync(userToLogin));
        }
    }
}