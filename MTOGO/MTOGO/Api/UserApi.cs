using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.UserDTO;
using MTOGO.Facades;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class UserApi : ControllerBase
{
    private readonly UserFacade _userFacade;
    
    public UserApi(UserFacade userFacade)
    {
        _userFacade = userFacade;
    }
    
    //Create user
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        try
        {
            UserDTO createdUser = await _userFacade.CreateUserAsync(userDto);
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
            UserDTO loggedInUser = await _userFacade.LoginUserAsync(userDto);
            return Ok(loggedInUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}