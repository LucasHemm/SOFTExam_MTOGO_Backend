using MTOGO.DTOs.UserDTO;

namespace MTOGO.Interfaces;

public interface IUserInterface
{
    Task<UserDTO> LoginUserAsync(UserDTO user);
    Task<UserDTO> CreateUserAsync(UserDTO user);
}