﻿using MTOGO.DTOs.RestaurantDTOs;

namespace MTOGO.Interfaces

{
    public interface IRestaurantFacade
    {
        Task<List<RestaurantDTO>> GetRestaurants();
        Task<RestaurantDTO> GetRestaurant(int id);
        Task<RestaurantDTO> CreateRestaurant(RestaurantDTO restaurant);
        Task<RestaurantDTO> UpdateRestaurant(RestaurantDTO restaurant);
        Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItem);
        Task<MenuItemDTO> UpdateMenuItem(MenuItemDTO menuItem);
        Task<List<MenuItemDTO>> GetMenuItems(int id);
    }
}
