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
    public IActionResult CreateAgent([FromBody] AgentDTO agentDto)
    {
        IAgentInterface agentFacade = _facadeFactory.GetAgentFacade();
        return Ok(agentFacade.CreateAgent(agentDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAgent(int id)
    {
        IAgentInterface agentFacade = _facadeFactory.GetAgentFacade();
        return Ok(agentFacade.GetAgent(id));
    }
}