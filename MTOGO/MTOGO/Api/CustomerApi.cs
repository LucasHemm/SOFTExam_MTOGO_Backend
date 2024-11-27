using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class CustomerApi : ControllerBase
{
    
    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerDTO customerDto)
    {
        return Ok(CustomerFacade.CreateCustomer(customerDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        return Ok(CustomerFacade.GetCustomer(id));
    }
  
}