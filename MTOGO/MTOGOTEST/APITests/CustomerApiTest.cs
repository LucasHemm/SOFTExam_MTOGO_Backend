// File: CustomerApiTests.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MTOGO.Api;
using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Facades;
using MTOGO.Interfaces;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Factories;

namespace MTOGO.Api.Tests
{
    public class CustomerApiTests
    {
        private readonly Mock<IFacadeFactory> _mockFacadeFactory;
        private readonly Mock<ICustomerInterface> _mockCustomerFacade;
        private readonly CustomerApi _controller;

        public CustomerApiTests()
        {
            _mockFacadeFactory = new Mock<IFacadeFactory>();
            _mockCustomerFacade = new Mock<ICustomerInterface>();

            // Setup the factory to return the mocked customer facade
            _mockFacadeFactory.Setup(f => f.GetCustomerFacade()).Returns(_mockCustomerFacade.Object);

            // Instantiate the controller with the mocked factory
            _controller = new CustomerApi(_mockFacadeFactory.Object);
        }

        [Fact]
        public async Task CreateCustomer_ReturnsOkResult_WithCreatedCustomer()
        {
            // Arrange
            var customerDto = new CustomerDTO
            {
                Id = 1,
                Email = "customer@example.com",
                PaymentInfoDTO = new PaymentInfoDTO
                {
                    Id = 1,
                    CardNumber = "1234567890123456",
                    ExpirationDate = "12/25"
                },
                AddressDTO = new AddressDTO
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "Anytown",
                    ZipCode = "12345",
                    Region = "RegionName"
                }
            };

            _mockCustomerFacade
                .Setup(facade => facade.CreateCustomer(It.IsAny<CustomerDTO>()))
                .ReturnsAsync(customerDto);

            // Act
            var result = await _controller.CreateCustomer(customerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCustomer = Assert.IsType<CustomerDTO>(okResult.Value);
            Assert.Equal(customerDto.Id, returnCustomer.Id);
            Assert.Equal(customerDto.Email, returnCustomer.Email);
            Assert.Equal(customerDto.PaymentInfoDTO.Id, returnCustomer.PaymentInfoDTO.Id);
            Assert.Equal(customerDto.PaymentInfoDTO.CardNumber, returnCustomer.PaymentInfoDTO.CardNumber);
            Assert.Equal(customerDto.PaymentInfoDTO.ExpirationDate, returnCustomer.PaymentInfoDTO.ExpirationDate);
            Assert.Equal(customerDto.AddressDTO.Id, returnCustomer.AddressDTO.Id);
            Assert.Equal(customerDto.AddressDTO.Street, returnCustomer.AddressDTO.Street);
            Assert.Equal(customerDto.AddressDTO.City, returnCustomer.AddressDTO.City);
            Assert.Equal(customerDto.AddressDTO.ZipCode, returnCustomer.AddressDTO.ZipCode);
            Assert.Equal(customerDto.AddressDTO.Region, returnCustomer.AddressDTO.Region);
        }

        [Fact]
        public async Task GetCustomer_ReturnsOkResult_WithCustomer()
        {
            // Arrange
            int customerId = 1;
            var customerDto = new CustomerDTO
            {
                Id = customerId,
                Email = "customer@example.com",
                PaymentInfoDTO = new PaymentInfoDTO
                {
                    Id = 1,
                    CardNumber = "1234567890123456",
                    ExpirationDate = "12/25"
                },
                AddressDTO = new AddressDTO
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "Anytown",
                    ZipCode = "12345",
                    Region = "RegionName"
                }
            };

            _mockCustomerFacade
                .Setup(facade => facade.GetCustomer(customerId))
                .ReturnsAsync(customerDto);

            // Act
            var result = await _controller.GetCustomer(customerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCustomer = Assert.IsType<CustomerDTO>(okResult.Value);
            Assert.Equal(customerDto.Id, returnCustomer.Id);
            Assert.Equal(customerDto.Email, returnCustomer.Email);
            Assert.Equal(customerDto.PaymentInfoDTO.Id, returnCustomer.PaymentInfoDTO.Id);
            Assert.Equal(customerDto.PaymentInfoDTO.CardNumber, returnCustomer.PaymentInfoDTO.CardNumber);
            Assert.Equal(customerDto.PaymentInfoDTO.ExpirationDate, returnCustomer.PaymentInfoDTO.ExpirationDate);
            Assert.Equal(customerDto.AddressDTO.Id, returnCustomer.AddressDTO.Id);
            Assert.Equal(customerDto.AddressDTO.Street, returnCustomer.AddressDTO.Street);
            Assert.Equal(customerDto.AddressDTO.City, returnCustomer.AddressDTO.City);
            Assert.Equal(customerDto.AddressDTO.ZipCode, returnCustomer.AddressDTO.ZipCode);
            Assert.Equal(customerDto.AddressDTO.Region, returnCustomer.AddressDTO.Region);
        }
    }
}
