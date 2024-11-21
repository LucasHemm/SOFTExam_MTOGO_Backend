using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.UserDTO;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class UserApi : ControllerBase
{
    
    //Create user
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        try
        {
            UserDTO createdUser = await UserFacade.CreateUser(userDto);
            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //Login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDTO userDto)
    {
        try
        {
            UserDTO loggedInUser = await UserFacade.LoginUser(userDto);
            return Ok(loggedInUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}