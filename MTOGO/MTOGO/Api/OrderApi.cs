using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class OrderApi : ControllerBase
{
    //Get all order
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        string json = await OrderFacade.GetAllOrders();
        return Ok(json);
    }
    
    //Get order by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        string json = await OrderFacade.GetOrder(id);
        return Ok(json);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem([FromBody] OrderDTO orderDto)
    {
        try
        {
            OrderDTO createdOrderDto = await OrderFacade.CreateOrder(orderDto);
            return Ok(createdOrderDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateStatusDTO orderDto)
    {
        try
        {
            OrderDTO updatedOrderDto = await OrderFacade.UpdateOrderStatus(orderDto);
            return Ok(updatedOrderDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}