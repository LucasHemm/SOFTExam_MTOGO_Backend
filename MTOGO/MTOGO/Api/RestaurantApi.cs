using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]

public class RestaurantApi : ControllerBase
{
    //Get all restaurants
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        List<RestaurantDTO> dtos = await RestaurantFacade.GetRestaurants();
        return Ok(dtos);
    }
    
}