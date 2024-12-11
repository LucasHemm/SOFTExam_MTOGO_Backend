using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]

public class RestaurantApi : ControllerBase
{
    
    private readonly IFacadeFactory _facadeFactory;
    
    public RestaurantApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
  
    
    //Get all restaurants
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
        List<RestaurantDTO> dtos = await restaurantFacade.GetRestaurants();
        return Ok(dtos);
    }
    
    //Get restaurant by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(int id)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            RestaurantDTO dto = await restaurantFacade.GetRestaurant(id);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Create restaurant
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantDTO restaurantDto)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            RestaurantDTO createdRestaurant = await restaurantFacade.CreateRestaurant(restaurantDto);
            return Ok(createdRestaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Update restaurant
    [HttpPut]
    public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantDTO restaurantDto)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            RestaurantDTO updatedRestaurant = await restaurantFacade.UpdateRestaurant(restaurantDto);
            return Ok(updatedRestaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Create menu item
    [HttpPost("MenuItem")]
    public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemDTO menuItemDto)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            MenuItemDTO createdMenuItem = await restaurantFacade.CreateMenuItem(menuItemDto);
            return Ok(createdMenuItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Update menu item
    [HttpPut("MenuItem")]
    public async Task<IActionResult> UpdateMenuItem([FromBody] MenuItemDTO menuItemDto)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            MenuItemDTO updatedMenuItem = await restaurantFacade.UpdateMenuItem(menuItemDto);
            return Ok(updatedMenuItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Get menu items by restaurant id
    [HttpGet("MenuItems/{id}")]
    public async Task<IActionResult> GetMenuItems(int id)
    {
        try
        {
            IRestaurantInterface restaurantFacade = _facadeFactory.GetResFacade();
            List<MenuItemDTO> dtos = await restaurantFacade.GetMenuItems(id);
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}