using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class CustomerApi : ControllerBase
{
    private readonly CustomerFacade _customerFacade;
    
    public CustomerApi(CustomerFacade customerFacade)
    {
        _customerFacade = customerFacade;
    }
    
    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerDTO customerDto)
    {
        return Ok(_customerFacade.CreateCustomer(customerDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        return Ok(_customerFacade.GetCustomer(id));
    }
  
}