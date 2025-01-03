// File: FeedbackFacadeTests.cs

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;
using MTOGO.Interfaces;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Facades.Tests
{
    public class FeedbackFacadeTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly Mock<IOrderInterface> _mockOrderFacade;
        private readonly Mock<IAgentInterface> _mockAgentFacade;
        private readonly Mock<IRestaurantInterface> _mockRestaurantFacade;
        private readonly FeedbackFacade _feedbackFacade;

        public FeedbackFacadeTests()
        {
            // Initialize mocks
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost/api/feedback/")
            };

            _mockOrderFacade = new Mock<IOrderInterface>();
            _mockAgentFacade = new Mock<IAgentInterface>();
            _mockRestaurantFacade = new Mock<IRestaurantInterface>();

            // Instantiate FeedbackFacade with mocked dependencies
            _feedbackFacade = new FeedbackFacade(
                _httpClient,
                _mockOrderFacade.Object,
                _mockAgentFacade.Object,
                _mockRestaurantFacade.Object
            );
        }

        [Fact]
        public async Task CreateFeedback_ShouldReturnCreatedFeedback_OnSuccess()
        {
            // Arrange
            var orderDto = new OrderDTO
            {
                Id = 1,
                OrderNumber = "ORD123",
                CustomerId = 10,
                AgentId = 5,
                RestaurantId = 2,
                OrderLinesDTOs = new List<OrderLineDTO>(),
                PaymentId = 100,
                TotalPrice = 250,
                Status = "Completed",
                Receipt = "Receipt123"
            };

            var feedbackDto = new FeedbackDTO
            {
                Id = 1,
                OrderDTO = orderDto,
                Title = "Great Service",
                Description = "The agent was very helpful.",
                Agentrating = 5,
                RestaurantRating = 4,
                OverAllRating = 5
            };

            var createdFeedbackJson = JsonSerializer.Serialize(feedbackDto);

            // Setup HttpClient mock for creating feedback (POST)
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post &&
                        req.RequestUri == new Uri("http://localhost/api/feedback/")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(createdFeedbackJson, System.Text.Encoding.UTF8, "application/json")
                });

            // Setup HttpClient mock for fetching feedbacks by agentId (GET)
            var agentFeedbacks = new List<FeedbackDTO>
            {
                new FeedbackDTO
                {
                    Id = 1,
                    OrderDTO = orderDto,
                    Title = "Great Service",
                    Description = "The agent was very helpful.",
                    Agentrating = 5,
                    RestaurantRating = 4,
                    OverAllRating = 5
                },
                new FeedbackDTO
                {
                    Id = 2,
                    OrderDTO = orderDto,
                    Title = "Good Support",
                    Description = "Agent was responsive.",
                    Agentrating = 4,
                    RestaurantRating = 5,
                    OverAllRating = 4
                }
            };

            var agentFeedbacksJson = JsonSerializer.Serialize(agentFeedbacks);

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri($"http://localhost/api/feedback/agent/{orderDto.AgentId}")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(agentFeedbacksJson, System.Text.Encoding.UTF8, "application/json")
                });

            // Setup HttpClient mock for fetching feedbacks by restaurantId (GET)
            var restaurantFeedbacks = new List<FeedbackDTO>
            {
                new FeedbackDTO
                {
                    Id = 1,
                    OrderDTO = orderDto,
                    Title = "Great Service",
                    Description = "The agent was very helpful.",
                    Agentrating = 5,
                    RestaurantRating = 4,
                    OverAllRating = 5
                },
                new FeedbackDTO
                {
                    Id = 3,
                    OrderDTO = orderDto,
                    Title = "Excellent Food",
                    Description = "Loved the dishes.",
                    Agentrating = 5,
                    RestaurantRating = 5,
                    OverAllRating = 5
                }
            };

            var restaurantFeedbacksJson = JsonSerializer.Serialize(restaurantFeedbacks);

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri($"http://localhost/api/feedback/restaurant/{orderDto.RestaurantId}")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(restaurantFeedbacksJson, System.Text.Encoding.UTF8, "application/json")
                });

            // Mock UpdateAgentRating and UpdateRestaurantRating to return completed tasks
            _mockAgentFacade
                .Setup(facade => facade.UpdateAgentRating(It.IsAny<UpdateRatingDTO>()))
                .Returns(Task.CompletedTask);

            _mockRestaurantFacade
                .Setup(facade => facade.UpdateRestaurantRating(It.IsAny<UpdateRatingDTO>()))
                .Returns(Task.CompletedTask);

            // Mock UpdateOrderStatus to return an updated OrderDTO
            var updatedOrder = new OrderDTO
            {
                Id = orderDto.Id,
                OrderNumber = orderDto.OrderNumber,
                CustomerId = orderDto.CustomerId,
                AgentId = orderDto.AgentId,
                RestaurantId = orderDto.RestaurantId,
                OrderLinesDTOs = orderDto.OrderLinesDTOs,
                PaymentId = orderDto.PaymentId,
                TotalPrice = orderDto.TotalPrice,
                Status = "completed", // Updated status in lowercase
                Receipt = orderDto.Receipt
            };

            _mockOrderFacade
                .Setup(facade => facade.UpdateOrderStatus(It.IsAny<UpdateStatusDTO>()))
                .ReturnsAsync(updatedOrder);

            // Act
            var createdFeedback = await _feedbackFacade.CreateFeedback(feedbackDto);

            // Assert
            Assert.NotNull(createdFeedback);
            Assert.Equal(feedbackDto.Id, createdFeedback.Id);
            Assert.Equal(feedbackDto.Title, createdFeedback.Title);
            Assert.Equal(feedbackDto.Description, createdFeedback.Description);
            Assert.Equal(feedbackDto.Agentrating, createdFeedback.Agentrating);
            Assert.Equal(feedbackDto.RestaurantRating, createdFeedback.RestaurantRating);
            Assert.Equal(feedbackDto.OverAllRating, createdFeedback.OverAllRating);
            Assert.Equal(feedbackDto.OrderDTO.Id, createdFeedback.OrderDTO.Id);
            Assert.Equal(feedbackDto.OrderDTO.OrderNumber, createdFeedback.OrderDTO.OrderNumber);
            Assert.Equal(feedbackDto.OrderDTO.CustomerId, createdFeedback.OrderDTO.CustomerId);
            Assert.Equal(feedbackDto.OrderDTO.AgentId, createdFeedback.OrderDTO.AgentId);
            Assert.Equal(feedbackDto.OrderDTO.RestaurantId, createdFeedback.OrderDTO.RestaurantId);
            Assert.Equal(feedbackDto.OrderDTO.PaymentId, createdFeedback.OrderDTO.PaymentId);
            Assert.Equal(feedbackDto.OrderDTO.TotalPrice, createdFeedback.OrderDTO.TotalPrice);
            Assert.Equal("Completed", createdFeedback.OrderDTO.Status); // Remains unchanged
            Assert.Equal(feedbackDto.OrderDTO.Receipt, createdFeedback.OrderDTO.Receipt);

            // Verify that CreateFeedback (POST) was called once
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri == new Uri("http://localhost/api/feedback/") &&
                    req.Content.ReadAsStringAsync().Result.Contains("Great Service")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            // Verify that GetFeedbacksByAgentId (GET) was called once
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri == new Uri($"http://localhost/api/feedback/agent/{orderDto.AgentId}")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            // Verify that GetFeedbacksByRestaurantId (GET) was called once
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri == new Uri($"http://localhost/api/feedback/restaurant/{orderDto.RestaurantId}")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            // Verify that UpdateAgentRating was called with correct parameters
            _mockAgentFacade.Verify(facade => facade.UpdateAgentRating(It.Is<UpdateRatingDTO>(dto =>
                dto.Id == orderDto.AgentId &&
                dto.Rating == (agentFeedbacks[0].Agentrating + agentFeedbacks[1].Agentrating) / 2.0 &&
                dto.NumberOfRatings == agentFeedbacks.Count
            )), Times.Once);

            // Verify that UpdateRestaurantRating was called with correct parameters
            _mockRestaurantFacade.Verify(facade => facade.UpdateRestaurantRating(It.Is<UpdateRatingDTO>(dto =>
                dto.Id == orderDto.RestaurantId &&
                dto.Rating == (restaurantFeedbacks[0].RestaurantRating + restaurantFeedbacks[1].RestaurantRating) / 2.0 &&
                dto.NumberOfRatings == restaurantFeedbacks.Count
            )), Times.Once);

            // Verify that UpdateOrderStatus was called once with correct parameters
            _mockOrderFacade.Verify(facade => facade.UpdateOrderStatus(It.Is<UpdateStatusDTO>(dto =>
                dto.OrderId == orderDto.Id &&
                dto.Status == "completed" // Changed to lowercase to match the method call
            )), Times.Once);
        }

        [Fact]
        public async Task GetFeedbacksByAgentId_ShouldReturnFeedbackList_OnSuccess()
        {
            // Arrange
            int agentId = 5;
            var feedbacks = new List<FeedbackDTO>
            {
                new FeedbackDTO
                {
                    Id = 1,
                    OrderDTO = new OrderDTO
                    {
                        Id = 1,
                        OrderNumber = "ORD123",
                        CustomerId = 10,
                        AgentId = agentId,
                        RestaurantId = 2,
                        OrderLinesDTOs = new List<OrderLineDTO>(),
                        PaymentId = 100,
                        TotalPrice = 250,
                        Status = "Completed",
                        Receipt = "Receipt123"
                    },
                    Title = "Great Service",
                    Description = "The agent was very helpful.",
                    Agentrating = 5,
                    RestaurantRating = 4,
                    OverAllRating = 5
                },
                new FeedbackDTO
                {
                    Id = 2,
                    OrderDTO = new OrderDTO
                    {
                        Id = 2,
                        OrderNumber = "ORD124",
                        CustomerId = 11,
                        AgentId = agentId,
                        RestaurantId = 3,
                        OrderLinesDTOs = new List<OrderLineDTO>(),
                        PaymentId = 101,
                        TotalPrice = 300,
                        Status = "Processing",
                        Receipt = "Receipt124"
                    },
                    Title = "Good Support",
                    Description = "Agent was responsive.",
                    Agentrating = 4,
                    RestaurantRating = 5,
                    OverAllRating = 4
                }
            };

            var feedbacksJson = JsonSerializer.Serialize(feedbacks);

            // Setup HttpClient mock for fetching feedbacks by agentId (GET)
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == new Uri($"http://localhost/api/feedback/agent/{agentId}")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(feedbacksJson, System.Text.Encoding.UTF8, "application/json")
                });

            // Act
            var result = await _feedbackFacade.GetFeedbacksByAgentId(agentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, feedback => Assert.Equal(agentId, feedback.OrderDTO.AgentId));

            // Verify that GetFeedbacksByAgentId was called once
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri == new Uri($"http://localhost/api/feedback/agent/{agentId}")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        // Additional tests for error scenarios can be added here
    }
}
