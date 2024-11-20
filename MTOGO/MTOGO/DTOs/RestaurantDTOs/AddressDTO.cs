﻿

namespace MTOGO.DTOs.RestaurantDTOs;

public class AddressDTO
{
    public int Id { get; set; } //primary key
    public String Street { get; set; }
    public String City { get; set; }
    public String ZipCode{ get; set; }
    public String Region { get; set; }
    
    public AddressDTO(int id, String street, String city, String zipCode, String region)
    {
        Id = id;
        Street = street;
        City = city;
        ZipCode = zipCode;
        Region = region;
    }

    public AddressDTO()
    {
    }


    
    //for creating a new address
    public AddressDTO(String street, String city, String zipCode, String region)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        Region = region;
    }
}