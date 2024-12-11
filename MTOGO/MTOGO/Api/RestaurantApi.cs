using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]

public class RestaurantApi : ControllerBase
{
    
    private readonly RestaurantFacade _restaurantFacade; 
    
    public RestaurantApi(RestaurantFacade restaurantFacade)
    {
        _restaurantFacade = restaurantFacade;
    }
    
    //Get all restaurants
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        List<RestaurantDTO> dtos = await _restaurantFacade.GetRestaurants();
        return Ok(dtos);
    }
    
    //Get restaurant by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(int id)
    {
        try
        {
            RestaurantDTO dto = await _restaurantFacade.GetRestaurant(id);
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
            RestaurantDTO createdRestaurant = await _restaurantFacade.CreateRestaurant(restaurantDto);
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
            RestaurantDTO updatedRestaurant = await _restaurantFacade.UpdateRestaurant(restaurantDto);
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
            MenuItemDTO createdMenuItem = await _restaurantFacade.CreateMenuItem(menuItemDto);
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
            MenuItemDTO updatedMenuItem = await _restaurantFacade.UpdateMenuItem(menuItemDto);
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
            List<MenuItemDTO> dtos = await _restaurantFacade.GetMenuItems(id);
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}