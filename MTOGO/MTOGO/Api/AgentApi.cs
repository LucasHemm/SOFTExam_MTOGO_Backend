using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class AgentApi : ControllerBase
{
    private readonly IFacadeFactory _facadeFactory;
    
    public AgentApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAgent([FromBody] AgentDTO agentDto)
    {
        IAgentInterface agentFacade = _facadeFactory.GetAgentFacade();
        var agent = await agentFacade.CreateAgent(agentDto);
        return Ok(agent);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAgent(int id)
    {
        IAgentInterface agentFacade = _facadeFactory.GetAgentFacade();
        var agent = await agentFacade.GetAgent(id);
        return Ok(agent);
    }
}