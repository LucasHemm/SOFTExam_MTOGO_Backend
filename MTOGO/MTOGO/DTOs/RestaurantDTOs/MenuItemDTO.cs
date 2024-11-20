﻿namespace MTOGO.DTOs.RestaurantDTOs;

public class MenuItemDTO
{
    public int Id { get; set; } //primary key
    public String ItemName { get; set; }
    public double Price  { get; set; }
    public String ItemDescription { get; set; }
    public int RestaurantId { get; set; }
    public string Image { get; set; }
    
    public MenuItemDTO(int id, String itemName, double price, String itemDescription, int restaurantId, string image)
    {
        Id = id;
        ItemName = itemName;
        Price = price;
        ItemDescription = itemDescription;
        RestaurantId = restaurantId;
        Image = image;
    }
    
    public MenuItemDTO()
    {
    }
}