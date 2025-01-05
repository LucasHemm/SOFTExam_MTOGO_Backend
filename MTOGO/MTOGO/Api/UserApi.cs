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
    private readonly ILogger<UserApi> _logger;
  
    public UserApi(ILogger<UserApi> logger, IFacadeFactory facadeFactory)
    {
        _logger = logger;
        _facadeFactory = facadeFactory;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        var now = DateTime.UtcNow.ToString("o"); 
        _logger.LogInformation(
            "Timestamp: {Timestamp} - CreateUser endpoint called with UserDTO: {@UserDTO}",
            now,
            userDto
        );

        try
        {
            IUserInterface userFacade = _facadeFactory.GetUserFacade();

            UserDTO createdUser = await userFacade.CreateUserAsync(userDto);

            _logger.LogInformation(
                "Timestamp: {Timestamp} - User created successfully with ID: {UserId}",
                now,
                createdUser.Id
            );

            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Timestamp: {Timestamp} - An error occurred while creating the user.",
                DateTime.UtcNow.ToString("o")
            );
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