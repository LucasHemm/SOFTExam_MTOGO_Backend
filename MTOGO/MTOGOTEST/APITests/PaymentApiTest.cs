using Microsoft.AspNetCore.Mvc;
using Moq;
using MTOGO.Api;
using MTOGO.DTOs.PaymentDTOs;
using MTOGO.Factories;
using MTOGO.Interfaces;
using PaymentService.DTOs;

namespace MTOGOTEST.APITests;

public class PaymentApiTest
{
    private readonly Mock<IFacadeFactory> _mockFacadeFactory;
    private readonly Mock<IPaymentInterface> _mockPaymentFacade;
    private readonly PaymentApi _controller;
    
    public PaymentApiTest()
    {
        _mockFacadeFactory = new Mock<IFacadeFactory>();
        _mockPaymentFacade = new Mock<IPaymentInterface>();
        
        // Setup the factory to return the mocked payment facade
        _mockFacadeFactory.Setup(f => f.GetPaymentFacade()).Returns(_mockPaymentFacade.Object);
        _controller = new PaymentApi(_mockFacadeFactory.Object);
    }

    [Fact]
    public async Task GetPayment_ReturnsOkResult_WithPayment()
    {
        // Arrange
        int paymentId = 1;
        var paymentDto = new PaymentDTO
        {
            Id = paymentId,
            TotalPrice = 100.0,
            Date = DateTime.UtcNow,
            PaymentProcessInfoDTO = new PaymentProcessInfoDTO
            {
                Id = 10,
                RestaurantEarnings = 80.0,
                AgentBonus = 15.0,
                MTOGOFee = 5.0
            }
        };

        _mockPaymentFacade
            .Setup(facade => facade.GetPaymentById(paymentId))
            .ReturnsAsync(paymentDto);

        // Act
        var result = await _controller.GetPayment(paymentId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnPayment = Assert.IsType<PaymentDTO>(okResult.Value);
        Assert.Equal(paymentDto.Id, returnPayment.Id);
        Assert.Equal(paymentDto.TotalPrice, returnPayment.TotalPrice);
        Assert.Equal(paymentDto.PaymentProcessInfoDTO.Id, returnPayment.PaymentProcessInfoDTO.Id);
    }

    [Fact]
    public async Task CreatePayment_ReturnsOkResult_WithCreatedPayment()
    {
        // Arrange
        var paymentRequest = new PaymentRequestDto
        {
            TotalPrice = 150.0,
            AgentRating = 4.5
        };

        var createdPayment = new PaymentDTO
        {
            Id = 2,
            TotalPrice = paymentRequest.TotalPrice,
            Date = DateTime.UtcNow,
            PaymentProcessInfoDTO = new PaymentProcessInfoDTO
            {
                Id = 11,
                RestaurantEarnings = 120.0,
                AgentBonus = 20.0,
                MTOGOFee = 10.0
            }
        };

        _mockPaymentFacade
            .Setup(facade => facade.CreatePayment(It.IsAny<PaymentRequestDto>()))
            .ReturnsAsync(createdPayment);

        // Act
        var result = await _controller.CreatePayment(paymentRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnPayment = Assert.IsType<PaymentDTO>(okResult.Value);
        Assert.Equal(createdPayment.Id, returnPayment.Id);
        Assert.Equal(createdPayment.TotalPrice, returnPayment.TotalPrice);
    }

        
    
}