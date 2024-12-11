using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.UserDTO;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api;

[ApiController]
[Route("api/[controller]")]
public class UserApi : ControllerBase
{
    private readonly IFacadeFactory _facadeFactory;
  
    public UserApi(IFacadeFactory facadeFactory)
    {
        _facadeFactory = facadeFactory;
    }
    
    //Create user
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        try
        {
            IUserInterface userFacade = _facadeFactory.GetUserFacade();
            UserDTO createdUser = await userFacade.CreateUserAsync(userDto);
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
            IUserInterface userFacade = _facadeFactory.GetUserFacade();
            UserDTO loggedInUser = await userFacade.LoginUserAsync(userDto);
            return Ok(loggedInUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}