using System.Net;
using System.Text.Json;
using MTOGO.DTOs;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;

namespace MTOGOTEST
{
    public class AgentFacadeTest
    {
        [Fact]
        public async Task CreateAgent_ShouldReturnAgentDTO_OnSuccess()
        {
            // Arrange
            var agentToCreate = new AgentDTO
            {
                Name = "John Doe",
                PhoneNumber = 1234567890,
                AccountNumber = "ACC123456",
                AgentId = "AGT001",
                Status = "Active",
                Region = "North",
                Rating = 4.5,
                NumberOfRatings = 10
            };
            var expectedResponse = new AgentDTO
            {
                Id = 1,
                Name = "John Doe",
                PhoneNumber = 1234567890,
                AccountNumber = "ACC123456",
                AgentId = "AGT001",
                Status = "Active",
                Region = "North",
                Rating = 4.5,
                NumberOfRatings = 10
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse), System.Text.Encoding.UTF8, "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery == "/" && req.Method == HttpMethod.Post);

            var agentFacade = new AgentFacade(httpClient);

            // Act
            var result = await agentFacade.CreateAgent(agentToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Name, result.Name);
            Assert.Equal(expectedResponse.PhoneNumber, result.PhoneNumber);
            Assert.Equal(expectedResponse.AccountNumber, result.AccountNumber);
            Assert.Equal(expectedResponse.AgentId, result.AgentId);
            Assert.Equal(expectedResponse.Status, result.Status);
            Assert.Equal(expectedResponse.Region, result.Region);
            Assert.Equal(expectedResponse.Rating, result.Rating);
            Assert.Equal(expectedResponse.NumberOfRatings, result.NumberOfRatings);
        }
        

        [Fact]
        public async Task GetAgent_ShouldReturnAgentDTO_OnSuccess()
        {
            // Arrange
            int agentId = 1;
            var expectedAgent = new AgentDTO
            {
                Id = agentId,
                Name = "Jane Smith",
                PhoneNumber = unchecked((int) 2345678901),
                AccountNumber = "ACC789012",
                AgentId = "AGT003",
                Status = "Active",
                Region = "East",
                Rating = 4.8,
                NumberOfRatings = 25
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedAgent), System.Text.Encoding.UTF8, "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery.EndsWith($"{agentId}") == true && req.Method == HttpMethod.Get);

            var agentFacade = new AgentFacade(httpClient);

            // Act
            var result = await agentFacade.GetAgent(agentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAgent.Id, result.Id);
            Assert.Equal(expectedAgent.Name, result.Name);
            Assert.Equal(expectedAgent.PhoneNumber, result.PhoneNumber);
            Assert.Equal(expectedAgent.AccountNumber, result.AccountNumber);
            Assert.Equal(expectedAgent.AgentId, result.AgentId);
            Assert.Equal(expectedAgent.Status, result.Status);
            Assert.Equal(expectedAgent.Region, result.Region);
            Assert.Equal(expectedAgent.Rating, result.Rating);
            Assert.Equal(expectedAgent.NumberOfRatings, result.NumberOfRatings);
        }
        
        [Fact]
        public async Task UpdateAgentRating_ShouldComplete_OnSuccess()
        {
            // Arrange
            var ratingDto = new UpdateRatingDTO
            {
                Id = 1,
                Rating = 4.9,
                NumberOfRatings = 26
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.NoContent); 

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery == "/rating" && req.Method == HttpMethod.Put);

            var agentFacade = new AgentFacade(httpClient);

            // Act & Assert
            await agentFacade.UpdateAgentRating(ratingDto);
        }
        
    }
}
