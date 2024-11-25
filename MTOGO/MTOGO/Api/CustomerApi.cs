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
    
    //Get customer by id
    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        return Ok(CustomerFacade.GetCustomer(id));
    }
    
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        return Ok(CustomerFacade.GetAllCustomers());
    }
    
    [HttpPut]
    public IActionResult UpdateCustomer([FromBody] CustomerDTO customerDto)
    {
        return Ok(CustomerFacade.UpdateCustomer(customerDto));
    }
  
}