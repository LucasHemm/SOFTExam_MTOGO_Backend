using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class AgentApi : ControllerBase
{
    private readonly AgentFacade _agentFacade;
    
    public AgentApi(AgentFacade agentFacade)
    {
        _agentFacade = agentFacade;
    }
    
    [HttpPost]
    public IActionResult CreateAgent([FromBody] AgentDTO agentDto)
    {
        return Ok(_agentFacade.CreateAgent(agentDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAgent(int id)
    {
        return Ok(_agentFacade.GetAgent(id));
    }
}