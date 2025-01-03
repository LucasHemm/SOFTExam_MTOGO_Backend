// File: OrderApiTests.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MTOGO.Api;
using MTOGO.DTOs;
using OrderAndFeedbackService.DTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api.Tests
{
    public class OrderApiTests
    {
        private readonly Mock<IFacadeFactory> _mockFacadeFactory;
        private readonly Mock<IOrderInterface> _mockOrderFacade;
        private readonly OrderApi _controller;

        public OrderApiTests()
        {
            _mockFacadeFactory = new Mock<IFacadeFactory>();
            _mockOrderFacade = new Mock<IOrderInterface>();

            // Setup the factory to return the mocked order facade
            _mockFacadeFactory.Setup(f => f.GetOrderFacade()).Returns(_mockOrderFacade.Object);

            // Instantiate the controller with the mocked factory
            _controller = new OrderApi(_mockFacadeFactory.Object);
        }

        [Fact]
        public async Task GetOrders_ReturnsOkResult_WithOrdersJson()
        {
            // Arrange
            var ordersJson = "[{\"Id\":1,\"OrderNumber\":\"ORD123\",\"CustomerId\":10,\"AgentId\":5,\"RestaurantId\":2,\"OrderLinesDTOs\":[],\"PaymentId\":100,\"TotalPrice\":250,\"Status\":\"Completed\",\"Receipt\":\"Receipt123\"}]";

            _mockOrderFacade
                .Setup(facade => facade.GetAllOrders())
                .ReturnsAsync(ordersJson);

            // Act
            var result = await _controller.GetOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(ordersJson, okResult.Value);
        }

        [Fact]
        public async Task GetOrder_ReturnsOkResult_WithOrderJson()
        {
            // Arrange
            int orderId = 1;
            var orderJson = "{\"Id\":1,\"OrderNumber\":\"ORD123\",\"CustomerId\":10,\"AgentId\":5,\"RestaurantId\":2,\"OrderLinesDTOs\":[],\"PaymentId\":100,\"TotalPrice\":250,\"Status\":\"Completed\",\"Receipt\":\"Receipt123\"}";

            _mockOrderFacade
                .Setup(facade => facade.GetOrder(orderId))
                .ReturnsAsync(orderJson);

            // Act
            var result = await _controller.GetOrder(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(orderJson, okResult.Value);
        }

        [Fact]
        public async Task CreateMenuItem_ReturnsOkResult_WithCreatedOrder()
        {
            // Arrange
            var newOrder = new OrderDTO
            {
                OrderNumber = "ORD124",
                CustomerId = 11,
                AgentId = 6,
                RestaurantId = 3,
                OrderLinesDTOs = new List<OrderLineDTO>(),
                PaymentId = 101,
                TotalPrice = 300,
                Status = "Pending",
                Receipt = "Receipt124"
            };

            var createdOrder = new OrderDTO
            {
                Id = 2,
                OrderNumber = "ORD124",
                CustomerId = 11,
                AgentId = 6,
                RestaurantId = 3,
                OrderLinesDTOs = new List<OrderLineDTO>(),
                PaymentId = 101,
                TotalPrice = 300,
                Status = "Pending",
                Receipt = "Receipt124"
            };

            _mockOrderFacade
                .Setup(facade => facade.CreateOrder(It.IsAny<OrderDTO>()))
                .ReturnsAsync(createdOrder);

            // Act
            var result = await _controller.CreateMenuItem(newOrder);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrder = Assert.IsType<OrderDTO>(okResult.Value);
            Assert.Equal(createdOrder.Id, returnOrder.Id);
            Assert.Equal("ORD124", returnOrder.OrderNumber);
            Assert.Equal(11, returnOrder.CustomerId);
            Assert.Equal(6, returnOrder.AgentId);
            Assert.Equal(3, returnOrder.RestaurantId);
            Assert.Equal(101, returnOrder.PaymentId);
            Assert.Equal(300, returnOrder.TotalPrice);
            Assert.Equal("Pending", returnOrder.Status);
            Assert.Equal("Receipt124", returnOrder.Receipt);
        }

        [Fact]
        public async Task UpdateOrderStatus_ReturnsOkResult_WithUpdatedOrder()
        {
            // Arrange
            var updateStatusDto = new UpdateStatusDTO
            {
                OrderId = 1,
                Status = "Shipped"
            };

            var updatedOrder = new OrderDTO
            {
                Id = 1,
                OrderNumber = "ORD123",
                CustomerId = 10,
                AgentId = 5,
                RestaurantId = 2,
                OrderLinesDTOs = new List<OrderLineDTO>(),
                PaymentId = 100,
                TotalPrice = 250,
                Status = "Shipped",
                Receipt = "Receipt123"
            };

            _mockOrderFacade
                .Setup(facade => facade.UpdateOrderStatus(It.IsAny<UpdateStatusDTO>()))
                .ReturnsAsync(updatedOrder);

            // Act
            var result = await _controller.UpdateOrderStatus(updateStatusDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrder = Assert.IsType<OrderDTO>(okResult.Value);
            Assert.Equal(updatedOrder.Id, returnOrder.Id);
            Assert.Equal("Shipped", returnOrder.Status);
        }

        [Fact]
        public async Task GetOrderByStatus_ReturnsOkResult_WithOrdersList()
        {
            // Arrange
            string status = "Completed";
            var orders = new List<OrderDTO>
            {
                new OrderDTO
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
                },
                new OrderDTO
                {
                    Id = 3,
                    OrderNumber = "ORD125",
                    CustomerId = 12,
                    AgentId = 7,
                    RestaurantId = 4,
                    OrderLinesDTOs = new List<OrderLineDTO>(),
                    PaymentId = 102,
                    TotalPrice = 350,
                    Status = "Completed",
                    Receipt = "Receipt125"
                }
            };

            _mockOrderFacade
                .Setup(facade => facade.GetOrdersByStatus(status))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrderByStatus(status);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrders = Assert.IsType<List<OrderDTO>>(okResult.Value);
            Assert.Equal(2, returnOrders.Count);
            Assert.All(returnOrders, order => Assert.Equal("Completed", order.Status));
        }

        [Fact]
        public async Task UpdateOrderIds_ReturnsOkResult_WithUpdatedOrder()
        {
            // Arrange
            var updateOrderIdsDto = new UpdateOrderIdsDTO(1,5,100);
           
            var updatedOrder = new OrderDTO
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

            _mockOrderFacade
                .Setup(facade => facade.UpdateOrder(It.IsAny<UpdateOrderIdsDTO>()))
                .ReturnsAsync(updatedOrder);

            // Act
            var result = await _controller.UpdateOrderIds(updateOrderIdsDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrder = Assert.IsType<OrderDTO>(okResult.Value);
            Assert.Equal(updatedOrder.Id, returnOrder.Id);
            Assert.Equal(updatedOrder.AgentId, returnOrder.AgentId);
            Assert.Equal(updatedOrder.PaymentId, returnOrder.PaymentId);
        }

        [Fact]
        public async Task GetOrderByAgent_ReturnsOkResult_WithOrdersList()
        {
            // Arrange
            int agentId = 5;
            var orders = new List<OrderDTO>
            {
                new OrderDTO
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
                new OrderDTO
                {
                    Id = 4,
                    OrderNumber = "ORD126",
                    CustomerId = 13,
                    AgentId = agentId,
                    RestaurantId = 5,
                    OrderLinesDTOs = new List<OrderLineDTO>(),
                    PaymentId = 103,
                    TotalPrice = 400,
                    Status = "Processing",
                    Receipt = "Receipt126"
                }
            };

            _mockOrderFacade
                .Setup(facade => facade.GetOrdersByAgentId(agentId))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrderByAgent(agentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrders = Assert.IsType<List<OrderDTO>>(okResult.Value);
            Assert.Equal(2, returnOrders.Count);
            Assert.All(returnOrders, order => Assert.Equal(agentId, order.AgentId));
        }

        [Fact]
        public async Task GetOrderByCustomer_ReturnsOkResult_WithOrdersList()
        {
            // Arrange
            int customerId = 10;
            var orders = new List<OrderDTO>
            {
                new OrderDTO
                {
                    Id = 1,
                    OrderNumber = "ORD123",
                    CustomerId = customerId,
                    AgentId = 5,
                    RestaurantId = 2,
                    OrderLinesDTOs = new List<OrderLineDTO>(),
                    PaymentId = 100,
                    TotalPrice = 250,
                    Status = "Completed",
                    Receipt = "Receipt123"
                },
                new OrderDTO
                {
                    Id = 5,
                    OrderNumber = "ORD127",
                    CustomerId = customerId,
                    AgentId = 8,
                    RestaurantId = 6,
                    OrderLinesDTOs = new List<OrderLineDTO>(),
                    PaymentId = 104,
                    TotalPrice = 500,
                    Status = "Delivered",
                    Receipt = "Receipt127"
                }
            };

            _mockOrderFacade
                .Setup(facade => facade.GetOrdersByCustomerID(customerId))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrderByCustomer(customerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrders = Assert.IsType<List<OrderDTO>>(okResult.Value);
            Assert.Equal(2, returnOrders.Count);
            Assert.All(returnOrders, order => Assert.Equal(customerId, order.CustomerId));
        }
    }
}
