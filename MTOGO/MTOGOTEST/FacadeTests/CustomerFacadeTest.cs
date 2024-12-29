using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Facades;
using MTOGO.Interfaces;
using Moq;
using Moq.Protected;
using Xunit;
using System.Collections.Generic;
using MTOGO.DTOs.RestaurantDTOs;

namespace MTOGO.Tests.Facades
{
    public class CustomerFacadeTests
    {
        
        [Fact]
        public async Task CreateCustomer_ShouldReturnCreatedCustomerDTO_OnSuccess()
        {
            // Arrange
            var customerToCreate = new CustomerDTO
            {
                Email = "john.doe@example.com",
                PaymentInfoDTO = new PaymentInfoDTO
                {
                    CardNumber = "1234567890123456",
                    ExpirationDate = "12/25"
                },
                AddressDTO = new AddressDTO
                {
                    Street = "123 Elm Street",
                    City = "Springfield",
                    ZipCode = "12345",
                    Region = "Region A"
                }
            };

            var createdCustomer = new CustomerDTO(
                id: 1,
                email: customerToCreate.Email,
                paymentInfoDto: customerToCreate.PaymentInfoDTO,
                addressDto: customerToCreate.AddressDTO
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonSerializer.Serialize(createdCustomer), System.Text.Encoding.UTF8, "application/json")
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
               .ReturnsAsync(responseMessage)
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var customerFacade = new CustomerFacade(httpClient);

            // Act
            var result = await customerFacade.CreateCustomer(customerToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdCustomer.Id, result.Id);
            Assert.Equal(createdCustomer.Email, result.Email);
            Assert.Equal(createdCustomer.PaymentInfoDTO.CardNumber, result.PaymentInfoDTO.CardNumber);
            Assert.Equal(createdCustomer.PaymentInfoDTO.ExpirationDate, result.PaymentInfoDTO.ExpirationDate);
            Assert.Equal(createdCustomer.AddressDTO.Street, result.AddressDTO.Street);
            Assert.Equal(createdCustomer.AddressDTO.City, result.AddressDTO.City);
            Assert.Equal(createdCustomer.AddressDTO.ZipCode, result.AddressDTO.ZipCode);
            Assert.Equal(createdCustomer.AddressDTO.Region, result.AddressDTO.Region);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post && req.RequestUri.PathAndQuery == "/"),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetCustomer_ShouldReturnCustomerDTO_OnSuccess()
        {
            // Arrange
            int customerId = 1;
            var expectedCustomer = new CustomerDTO(
                id: customerId,
                email: "john.doe@example.com",
                paymentInfoDto: new PaymentInfoDTO(1, "1234567890123456", "12/25"),
                addressDto: new AddressDTO(1, "123 Elm Street", "Springfield", "12345", "Region A")
            );

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedCustomer), System.Text.Encoding.UTF8, "application/json")
            };

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.Is<HttpRequestMessage>(req =>
                       req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/{customerId}"),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage)
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            var customerFacade = new CustomerFacade(httpClient);

            // Act
            var result = await customerFacade.GetCustomer(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCustomer.Id, result.Id);
            Assert.Equal(expectedCustomer.Email, result.Email);
            Assert.Equal(expectedCustomer.PaymentInfoDTO.CardNumber, result.PaymentInfoDTO.CardNumber);
            Assert.Equal(expectedCustomer.PaymentInfoDTO.ExpirationDate, result.PaymentInfoDTO.ExpirationDate);
            Assert.Equal(expectedCustomer.AddressDTO.Street, result.AddressDTO.Street);
            Assert.Equal(expectedCustomer.AddressDTO.City, result.AddressDTO.City);
            Assert.Equal(expectedCustomer.AddressDTO.ZipCode, result.AddressDTO.ZipCode);
            Assert.Equal(expectedCustomer.AddressDTO.Region, result.AddressDTO.Region);

            // Verify that the correct HTTP request was made
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get && req.RequestUri.PathAndQuery == $"/{customerId}"),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
