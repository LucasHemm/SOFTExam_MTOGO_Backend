using MTOGO.DTOs.RestaurantDTOs;

using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;

namespace MTOGO.Interfaces
{
    public interface IRestaurantInterface
    {
        Task<List<RestaurantDTO>> GetRestaurants();
        Task<RestaurantDTO> GetRestaurant(int id);
        Task<RestaurantDTO> CreateRestaurant(RestaurantDTO restaurant);
        Task<RestaurantDTO> UpdateRestaurant(RestaurantDTO restaurant);
        Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItem);
        Task<MenuItemDTO> UpdateMenuItem(MenuItemDTO menuItem);
        Task<List<MenuItemDTO>> GetMenuItems(int id);
        Task UpdateRestaurantRating(UpdateRatingDTO ratingDto);
    }
}