using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class CustomerApi : ControllerBase
{
    private readonly IFacadeFactory _facadeFactory;
    
    public CustomerApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDto)
    {
        ICustomerInterface customerFacade = _facadeFactory.GetCustomerFacade();
        var createdCustomer = await customerFacade.CreateCustomer(customerDto); 
        return Ok(createdCustomer);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        ICustomerInterface customerFacade = _facadeFactory.GetCustomerFacade();
        var customer = await customerFacade.GetCustomer(id); 
        return Ok(customer); 
    }

  
}