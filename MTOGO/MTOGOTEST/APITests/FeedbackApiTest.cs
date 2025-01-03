// File: FeedbackApiTests.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MTOGO.Api;
using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Api.Tests
{
    public class FeedbackApiTests
    {
        private readonly Mock<IFacadeFactory> _mockFacadeFactory;
        private readonly Mock<IFeedbackInterface> _mockFeedbackFacade;
        private readonly FeedbackApi _controller;

        public FeedbackApiTests()
        {
            _mockFacadeFactory = new Mock<IFacadeFactory>();
            _mockFeedbackFacade = new Mock<IFeedbackInterface>();

            // Setup the factory to return the mocked feedback facade
            _mockFacadeFactory.Setup(f => f.GetFeedbackFacade()).Returns(_mockFeedbackFacade.Object);

            // Instantiate the controller with the mocked factory
            _controller = new FeedbackApi(_mockFacadeFactory.Object);
        }

        [Fact]
        public async Task CreateFeedback_ReturnsOkResult_WithCreatedFeedback()
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

            var createdFeedback = new FeedbackDTO
            {
                Id = 1,
                OrderDTO = orderDto,
                Title = "Great Service",
                Description = "The agent was very helpful.",
                Agentrating = 5,
                RestaurantRating = 4,
                OverAllRating = 5
            };

            _mockFeedbackFacade
                .Setup(facade => facade.CreateFeedback(It.IsAny<FeedbackDTO>()))
                .ReturnsAsync(createdFeedback);

            // Act
            var result = await _controller.CreateFeedback(feedbackDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnFeedback = Assert.IsType<FeedbackDTO>(okResult.Value);
            Assert.Equal(createdFeedback.Id, returnFeedback.Id);
            Assert.Equal(createdFeedback.Title, returnFeedback.Title);
            Assert.Equal(createdFeedback.Description, returnFeedback.Description);
            Assert.Equal(createdFeedback.Agentrating, returnFeedback.Agentrating);
            Assert.Equal(createdFeedback.RestaurantRating, returnFeedback.RestaurantRating);
            Assert.Equal(createdFeedback.OverAllRating, returnFeedback.OverAllRating);
            Assert.Equal(createdFeedback.OrderDTO.Id, returnFeedback.OrderDTO.Id);
            Assert.Equal(createdFeedback.OrderDTO.OrderNumber, returnFeedback.OrderDTO.OrderNumber);
            Assert.Equal(createdFeedback.OrderDTO.CustomerId, returnFeedback.OrderDTO.CustomerId);
            Assert.Equal(createdFeedback.OrderDTO.AgentId, returnFeedback.OrderDTO.AgentId);
            Assert.Equal(createdFeedback.OrderDTO.RestaurantId, returnFeedback.OrderDTO.RestaurantId);
            Assert.Equal(createdFeedback.OrderDTO.PaymentId, returnFeedback.OrderDTO.PaymentId);
            Assert.Equal(createdFeedback.OrderDTO.TotalPrice, returnFeedback.OrderDTO.TotalPrice);
            Assert.Equal(createdFeedback.OrderDTO.Status, returnFeedback.OrderDTO.Status);
            Assert.Equal(createdFeedback.OrderDTO.Receipt, returnFeedback.OrderDTO.Receipt);
        }
    }
}
