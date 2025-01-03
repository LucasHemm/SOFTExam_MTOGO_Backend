using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;
using MTOGO.DTOs;
using MTOGO.Facades;
using OrderAndFeedbackService.DTOs;

namespace MTOGOTEST.FacadeTests
{
    public class OrderFacadeTests
    {
      

        [Fact]
        public async Task GetAllOrders_ShouldReturnString_OnSuccess()
        {
            // Arrange
            var expectedResponse = "[{\"Id\": 1}, {\"Id\": 2}]"; // Example JSON
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse)
            };

            // Create the mock
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == "/"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage)
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.GetAllOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Id", result);
            Assert.Equal(expectedResponse, result);

            // Verify
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }
        
        [Fact]
        public async Task GetOrder_ShouldReturnString_OnSuccess()
        {
            // Arrange
            int orderId = 1;
            var expectedResponse = "{\"Id\":1,\"OrderNumber\":\"ABC123\"}";
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse)
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get &&
                       req.RequestUri.PathAndQuery == $"/{orderId}"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.GetOrder(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("OrderNumber", result);
            Assert.Equal(expectedResponse, result);
        }

      
        [Fact]
        public async Task CreateOrder_ShouldReturnOrderDTO_OnSuccess()
        {
            // Arrange
            var orderToCreate = new OrderDTO
            {
                Id = 0,
                CustomerId = 10,
                AgentId = 20,
                RestaurantId = 30,
                Status = "New",
                TotalPrice = 999,
                OrderLinesDTOs = new List<OrderLineDTO>
                {
                    new OrderLineDTO(1, 100, 0, 2),
                    new OrderLineDTO(2, 101, 0, 3)
                }
            };

            var createdOrder = new OrderDTO
            {
                Id = 1,
                CustomerId = orderToCreate.CustomerId,
                AgentId = orderToCreate.AgentId,
                RestaurantId = orderToCreate.RestaurantId,
                Status = orderToCreate.Status,
                TotalPrice = orderToCreate.TotalPrice,
                OrderLinesDTOs = orderToCreate.OrderLinesDTOs
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(createdOrder))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.CreateOrder(orderToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdOrder.Id, result.Id);
            Assert.Equal(createdOrder.CustomerId, result.CustomerId);
            Assert.Equal(createdOrder.AgentId, result.AgentId);
            Assert.Equal(createdOrder.Status, result.Status);
            Assert.Equal(createdOrder.TotalPrice, result.TotalPrice);
            Assert.Equal(createdOrder.OrderLinesDTOs.Count, result.OrderLinesDTOs.Count);
        }
        

        [Fact]
        public async Task UpdateOrderStatus_ShouldReturnOrderDTO_OnSuccess()
        {
            // Arrange
            var statusDto = new UpdateStatusDTO(1, "InProgress");
            var updatedOrder = new OrderDTO
            {
                Id = 1,
                Status = "InProgress"
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(updatedOrder))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.UpdateOrderStatus(statusDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedOrder.Id, result.Id);
            Assert.Equal(updatedOrder.Status, result.Status);
        }
        

        [Fact]
        public async Task GetOrdersByStatus_ShouldReturnListOfOrderDTO_OnSuccess()
        {
            // Arrange
            var status = "Completed";
            var expectedOrders = new List<OrderDTO>
            {
                new OrderDTO { Id = 1, Status = "Completed" },
                new OrderDTO { Id = 2, Status = "Completed" }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedOrders))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get &&
                       req.RequestUri.PathAndQuery == $"/status/{status}"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.GetOrdersByStatus(status);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrders.Count, result.Count);
            Assert.All(result, o => Assert.Equal("Completed", o.Status));
        }

       
        [Fact]
        public async Task UpdateOrder_ShouldReturnOrderDTO_OnSuccess()
        {
            // Arrange
            var updateDto = new UpdateOrderIdsDTO(orderID: 1, agentID: 10, paymentID: 50);
            var updatedOrder = new OrderDTO
            {
                Id = 1,
                AgentId = 10,
                PaymentId = 50
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(updatedOrder))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Put && req.RequestUri.PathAndQuery == "/UpdateIds"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.UpdateOrder(updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedOrder.Id, result.Id);
            Assert.Equal(updatedOrder.AgentId, result.AgentId);
            Assert.Equal(updatedOrder.PaymentId, result.PaymentId);
        }

        

        [Fact]
        public async Task GetOrdersByAgentId_ShouldReturnListOfOrderDTO_OnSuccess()
        {
            // Arrange
            int agentId = 10;
            var expectedOrders = new List<OrderDTO>
            {
                new OrderDTO { Id = 1, AgentId = agentId },
                new OrderDTO { Id = 2, AgentId = agentId }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedOrders))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get &&
                       req.RequestUri.PathAndQuery == $"/agent/{agentId}"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.GetOrdersByAgentId(agentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrders.Count, result.Count);
            Assert.All(result, o => Assert.Equal(agentId, o.AgentId));
        }
        
        [Fact]
        public async Task GetOrdersByCustomerID_ShouldReturnListOfOrderDTO_OnSuccess()
        {
            // Arrange
            int customerId = 5;
            var expectedOrders = new List<OrderDTO>
            {
                new OrderDTO { Id = 1, CustomerId = customerId },
                new OrderDTO { Id = 2, CustomerId = customerId }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedOrders))
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get &&
                       req.RequestUri.PathAndQuery == $"/customer/{customerId}"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };
            var orderFacade = new OrderFacade(httpClient);

            // Act
            var result = await orderFacade.GetOrdersByCustomerID(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrders.Count, result.Count);
            Assert.All(result, o => Assert.Equal(customerId, o.CustomerId));
        }
    }
}
