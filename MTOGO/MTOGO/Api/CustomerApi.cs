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
    public IActionResult CreateCustomer([FromBody] CustomerDTO customerDto)
    {
        ICustomerInterface customerFacade = _facadeFactory.GetCustomerFacade();
        return Ok(customerFacade.CreateCustomer(customerDto));
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        ICustomerInterface customerFacade = _facadeFactory.GetCustomerFacade();
        return Ok(customerFacade.GetCustomer(id));
    }
  
}