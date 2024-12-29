using System.Net;
using System.Text.Json;
using MTOGO.DTOs.PaymentDTOs;
using MTOGO.Facades;
using PaymentService.DTOs;

namespace MTOGOTEST
{
    public class PaymentFacadeTest
    {
   
        [Fact]
        public async Task GetPaymentById_ShouldReturnPaymentDTO_OnSuccess()
        {
            // Arrange
            int paymentId = 1;
            var expectedPayment = new PaymentDTO
            {
                Id = paymentId,
                TotalPrice = 150.75,
                Date = DateTime.UtcNow,
                PaymentProcessInfoDTO = new PaymentProcessInfoDTO
                {
                    Id = 10,
                    RestaurantEarnings = 100.50,
                    AgentBonus = 30.00,
                    MTOGOFee = 20.25
                }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedPayment), System.Text.Encoding.UTF8, "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery.EndsWith($"{paymentId}") == true && req.Method == HttpMethod.Get);

            var paymentFacade = new PaymentFacade(httpClient);

            // Act
            var result = await paymentFacade.GetPaymentById(paymentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPayment.Id, result.Id);
            Assert.Equal(expectedPayment.TotalPrice, result.TotalPrice);
            Assert.Equal(expectedPayment.Date, result.Date);
            Assert.NotNull(result.PaymentProcessInfoDTO);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.Id, result.PaymentProcessInfoDTO.Id);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.RestaurantEarnings, result.PaymentProcessInfoDTO.RestaurantEarnings);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.AgentBonus, result.PaymentProcessInfoDTO.AgentBonus);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.MTOGOFee, result.PaymentProcessInfoDTO.MTOGOFee);
        }
        
        [Fact]
        public async Task CreatePayment_ShouldReturnPaymentDTO_OnSuccess()
        {
            // Arrange
            var paymentRequest = new PaymentRequestDto
            {
                TotalPrice = 200.00,
                AgentRating = 4.7
            };

            var expectedPayment = new PaymentDTO
            {
                Id = 2,
                TotalPrice = 200.00,
                Date = DateTime.UtcNow,
                PaymentProcessInfoDTO = new PaymentProcessInfoDTO
                {
                    Id = 11,
                    RestaurantEarnings = 133.33,
                    AgentBonus = 40.00,
                    MTOGOFee = 26.67
                }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedPayment), System.Text.Encoding.UTF8, "application/json")
            };

            var httpClient = HttpClientMock.GetMockedHttpClient(responseMessage,
                req => req.RequestUri?.PathAndQuery == "/" && req.Method == HttpMethod.Post);

            var paymentFacade = new PaymentFacade(httpClient);

            // Act
            var result = await paymentFacade.CreatePayment(paymentRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPayment.Id, result.Id);
            Assert.Equal(expectedPayment.TotalPrice, result.TotalPrice);
            Assert.Equal(expectedPayment.Date, result.Date);
            Assert.NotNull(result.PaymentProcessInfoDTO);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.Id, result.PaymentProcessInfoDTO.Id);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.RestaurantEarnings, result.PaymentProcessInfoDTO.RestaurantEarnings);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.AgentBonus, result.PaymentProcessInfoDTO.AgentBonus);
            Assert.Equal(expectedPayment.PaymentProcessInfoDTO.MTOGOFee, result.PaymentProcessInfoDTO.MTOGOFee);
        }
    }
}
