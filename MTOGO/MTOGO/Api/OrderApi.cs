using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class OrderApi : ControllerBase
{
    
    private readonly IFacadeFactory _facadeFactory;
    
    public OrderApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
  
    
    //Get all order
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
        string json = await orderFacade.GetAllOrders();
        return Ok(json);
    }
    
    //Get order by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
        string json = await orderFacade.GetOrder(id);
        return Ok(json);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem([FromBody] OrderDTO orderDto)
    {
        try
        {
            IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
            OrderDTO createdOrderDto = await orderFacade.CreateOrder(orderDto);
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
            IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
            OrderDTO updatedOrderDto = await orderFacade.UpdateOrderStatus(orderDto);
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
        IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
        List<OrderDTO> json = await orderFacade.GetOrdersByStatus(status);
        return Ok(json);
    }
    
    [HttpPut("updateIds")]
    public async Task<IActionResult> UpdateOrderIds([FromBody] UpdateOrderIdsDTO Dto)
    {
        try
        {
            IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
            OrderDTO updatedOrderDto = await orderFacade.UpdateOrder(Dto);
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
        IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
        List<OrderDTO> json = await orderFacade.GetOrdersByAgentId(id);
        return Ok(json);
    }
    
    [HttpGet("customer/{id}")]
    public async Task<IActionResult> GetOrderByCustomer(int id)
    {
        IOrderInterface orderFacade = _facadeFactory.GetOrderFacade();
        List<OrderDTO> json = await orderFacade.GetOrdersByCustomerID(id);
        return Ok(json);
    }
}