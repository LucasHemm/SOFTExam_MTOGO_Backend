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
    
    public static async Task<RestaurantDTO> GetRestaurant(int id)
    {
        var response = await HttpClient.GetAsync($"http://localhost:5176/api/restaurantapi/{id}");
        response.EnsureSuccessStatusCode();
        var restaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
        return restaurant;
    }
    
    public static async Task<RestaurantDTO> CreateRestaurant(RestaurantDTO restaurant)
    {
        var response = await HttpClient.PostAsJsonAsync("http://localhost:5176/api/restaurantapi", restaurant);
        response.EnsureSuccessStatusCode();
        var createdRestaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
        return createdRestaurant;
    }
    
    public static async Task<RestaurantDTO> UpdateRestaurant(RestaurantDTO restaurant)
    {
        var response = await HttpClient.PutAsJsonAsync("http://localhost:5176/api/restaurantapi", restaurant);
        response.EnsureSuccessStatusCode();
        var updatedRestaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
        return updatedRestaurant;
    }
    
    public static async Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItem)
    {
        var response = await HttpClient.PostAsJsonAsync("http://localhost:5176/api/restaurantapi/menuitem", menuItem);
        response.EnsureSuccessStatusCode();
        var createdMenuItem = await response.Content.ReadFromJsonAsync<MenuItemDTO>();
        return createdMenuItem;
    }
    
    public static async Task<MenuItemDTO> UpdateMenuItem(MenuItemDTO menuItem)
    {
        var response = await HttpClient.PutAsJsonAsync("http://localhost:5176/api/restaurantapi/menuitem", menuItem);
        response.EnsureSuccessStatusCode();
        var updatedMenuItem = await response.Content.ReadFromJsonAsync<MenuItemDTO>();
        return updatedMenuItem;
    }
    
    public static async Task<List<MenuItemDTO>> GetMenuItems(int id)
    {
        var response = await HttpClient.GetAsync($"http://localhost:5176/api/restaurantapi/menuitems/{id}");
        response.EnsureSuccessStatusCode();
        var menuItems = await response.Content.ReadFromJsonAsync<List<MenuItemDTO>>();
        return menuItems;
    }
    
}