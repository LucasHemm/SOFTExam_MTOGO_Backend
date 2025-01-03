using Microsoft.AspNetCore.Mvc;
using Moq;
using MTOGO.Api;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGOTEST.APITests;

public class AgentApiTest
{
    private readonly Mock<IFacadeFactory> _mockFacadeFactory;
    private readonly Mock<IAgentInterface> _mockAgentFacade;
    private readonly AgentApi _controller;
    
    public AgentApiTest()
    {
        _mockFacadeFactory = new Mock<IFacadeFactory>();
        _mockAgentFacade = new Mock<IAgentInterface>();
        
        // Setup the factory to return the mocked agent facade
        _mockFacadeFactory.Setup(f => f.GetAgentFacade()).Returns(_mockAgentFacade.Object);
        _controller = new AgentApi(_mockFacadeFactory.Object);
    }

    [Fact]
    public async Task CreateAgent_ReturnsOkResult_WithCreatedAgent()
    {
        // Arrange
        var agentDto = new AgentDTO
        {
            Id = 0, Name = "Test Agent", PhoneNumber = 1234567890, AccountNumber = "1234567890", AgentId = "1234567890",
            Status = "Active", Region = "Test Region", Rating = 4.5, NumberOfRatings = 10
        };

        _mockAgentFacade
            .Setup(facade => facade.CreateAgent(It.IsAny<AgentDTO>()))
            .ReturnsAsync(agentDto);

        // Act

        var result = await _controller.CreateAgent(agentDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAgent = Assert.IsType<AgentDTO>(okResult.Value);
        Assert.Equal(agentDto.Name, returnAgent.Name);
    }
    
    [Fact]
    public async Task GetAgent_ReturnsOkResult_WithAgent()
    {
        // Arrange
        var agentDto = new AgentDTO
        {
            Id = 1, Name = "Test Agent", PhoneNumber = 1234567890, AccountNumber = "1234567890", AgentId = "1234567890",
            Status = "Active", Region = "Test Region", Rating = 4.5, NumberOfRatings = 10
        };

        _mockAgentFacade
            .Setup(facade => facade.GetAgent(It.IsAny<int>()))
            .ReturnsAsync(agentDto);

        // Act
        var result = await _controller.GetAgent(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnAgent = Assert.IsType<AgentDTO>(okResult.Value);
        Assert.Equal(agentDto.Id, returnAgent.Id);
    }
}