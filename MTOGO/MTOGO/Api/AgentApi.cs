using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class AgentApi : ControllerBase
{
    
    [HttpPost]
    public IActionResult CreateAgent([FromBody] AgentDTO agentDto)
    {
        return Ok(AgentFacade.CreateAgent(agentDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAgent(int id)
    {
        return Ok(AgentFacade.GetAgent(id));
    }
}