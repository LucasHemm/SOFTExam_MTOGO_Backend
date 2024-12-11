using MTOGO.DTOs.RestaurantDTOs;
using MTOGO.Interfaces;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using MTOGO.DTOs;

namespace MTOGO.Facades
{
    public class RestaurantFacade : BaseFacade, IRestaurantInterface
    {
        public RestaurantFacade(HttpClient httpClient) : base(httpClient) { }

        public async Task<List<RestaurantDTO>> GetRestaurants()
        {
            try
            {
                var response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();
                var restaurants = await response.Content.ReadFromJsonAsync<List<RestaurantDTO>>();
                return restaurants;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching restaurants: {e}");
                throw;
            }
        }

        public async Task<RestaurantDTO> GetRestaurant(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}");
                response.EnsureSuccessStatusCode();
                var restaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
                return restaurant;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching restaurant with ID {id}: {e}");
                throw;
            }
        }

        public async Task<RestaurantDTO> CreateRestaurant(RestaurantDTO restaurant)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", restaurant);
                response.EnsureSuccessStatusCode();
                var createdRestaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
                return createdRestaurant;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating restaurant: {e}");
                throw;
            }
        }

        public async Task<RestaurantDTO> UpdateRestaurant(RestaurantDTO restaurant)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("", restaurant);
                response.EnsureSuccessStatusCode();
                var updatedRestaurant = await response.Content.ReadFromJsonAsync<RestaurantDTO>();
                return updatedRestaurant;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error updating restaurant: {e}");
                throw;
            }
        }

        public async Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItem)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("menuitem", menuItem);
                response.EnsureSuccessStatusCode();
                var createdMenuItem = await response.Content.ReadFromJsonAsync<MenuItemDTO>();
                return createdMenuItem;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating menu item: {e}");
                throw;
            }
        }

        public async Task<MenuItemDTO> UpdateMenuItem(MenuItemDTO menuItem)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("menuitem", menuItem);
                response.EnsureSuccessStatusCode();
                var updatedMenuItem = await response.Content.ReadFromJsonAsync<MenuItemDTO>();
                return updatedMenuItem;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error updating menu item: {e}");
                throw;
            }
        }

        public async Task<List<MenuItemDTO>> GetMenuItems(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"menuitems/{id}");
                response.EnsureSuccessStatusCode();
                var menuItems = await response.Content.ReadFromJsonAsync<List<MenuItemDTO>>();
                return menuItems;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching menu items for restaurant ID {id}: {e}");
                throw;
            }
        }

        public async Task UpdateRestaurantRating(UpdateRatingDTO ratingDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("rating", ratingDto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error updating restaurant rating: {e}");
                throw;
            }
        }
    }
}
