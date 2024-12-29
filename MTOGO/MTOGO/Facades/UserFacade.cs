using MTOGO.DTOs.UserDTO;
using MTOGO.Interfaces;

namespace MTOGO.Facades;

public class UserFacade : BaseFacade, IUserInterface
{
    public UserFacade(HttpClient httpClient) : base(httpClient) { }

    public async Task<UserDTO> LoginUserAsync(UserDTO user)
    {
        var response = await _httpClient.PostAsJsonAsync("login", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDTO>() ?? throw new InvalidOperationException();
    }

    public async Task<UserDTO> CreateUserAsync(UserDTO user)
    {
        var response = await _httpClient.PostAsJsonAsync("", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDTO>() ?? throw new InvalidOperationException();
    }
}