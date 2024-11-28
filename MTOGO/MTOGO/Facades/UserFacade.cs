using MTOGO.DTOs.UserDTO;

namespace MTOGO.Facades;

public class UserFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();
    
    public static Task<UserDTO> LoginUser(UserDTO user)
    {
        return HttpClient.PostAsJsonAsync("http://user_app:8080/api/userapi/login", user).Result.Content.ReadFromJsonAsync<UserDTO>();
    }
    
    public static Task<UserDTO> CreateUser(UserDTO user)
    {
        return HttpClient.PostAsJsonAsync("http://user_app:8080/api/userapi", user).Result.Content.ReadFromJsonAsync<UserDTO>();
    }
}