using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.Facades;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class OrderApi : ControllerBase
{
    
    private readonly OrderFacade _orderFacade;
    
    public OrderApi(OrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }
    
    //Get all order
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        string json = await _orderFacade.GetAllOrders();
        return Ok(json);
    }
    
    //Get order by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        string json = await _orderFacade.GetOrder(id);
        return Ok(json);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem([FromBody] OrderDTO orderDto)
    {
        try
        {
            OrderDTO createdOrderDto = await _orderFacade.CreateOrder(orderDto);
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
            OrderDTO updatedOrderDto = await _orderFacade.UpdateOrderStatus(orderDto);
            return Ok(updatedOrderDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetOrderByStatus(string status)
    {
        List<OrderDTO> json = await _orderFacade.GetOrdersByStatus(status);
        return Ok(json);
    }
    
    [HttpPut("updateIds")]
    public async Task<IActionResult> UpdateOrderIds([FromBody] UpdateOrderIdsDTO Dto)
    {
        try
        {
            OrderDTO updatedOrderDto = await _orderFacade.UpdateOrder(Dto);
            return Ok(updatedOrderDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("agent/{id}")]
    public async Task<IActionResult> GetOrderByAgent(int id)
    {
        List<OrderDTO> json = await _orderFacade.GetOrdersByAgentId(id);
        return Ok(json);
    }
    
    [HttpGet("customer/{id}")]
    public async Task<IActionResult> GetOrderByCustomer(int id)
    {
        List<OrderDTO> json = await _orderFacade.GetOrdersByCustomerID(id);
        return Ok(json);
    }
    
    
    
}