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
        return Ok(await agentFacade.CreateAgent(agentDto));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAgent(int id)
    {
        IAgentInterface agentFacade = _facadeFactory.GetAgentFacade();
        return Ok(await agentFacade.GetAgent(id));
    }
}