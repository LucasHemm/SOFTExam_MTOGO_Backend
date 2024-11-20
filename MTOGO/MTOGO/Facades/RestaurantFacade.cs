using MTOGO.DTOs.RestaurantDTOs;

namespace MTOGO.Facades;

public class RestaurantFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();
    
    public static async Task<List<RestaurantDTO>> GetRestaurants()
    {
        var response = await HttpClient.GetAsync("http://localhost:5176/api/restaurantapi");
        response.EnsureSuccessStatusCode();
        var restaurants = await response.Content.ReadFromJsonAsync<List<RestaurantDTO>>();
        return restaurants;
    }
    
}