﻿using MTOGO.DTOs.CustomerDTOs;

namespace MTOGO.Facades;

public class CustomerFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();
    private static readonly string _baseUrl = "http://localhost:5042/api/customerapi";
    
    public static CustomerDTO CreateCustomer(CustomerDTO customerDto)
    {
        var response = HttpClient.PostAsJsonAsync($"{_baseUrl}", customerDto).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<CustomerDTO>().Result;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
    
    public static CustomerDTO UpdateCustomer(CustomerDTO customerDto)
    {
        var response = HttpClient.PutAsJsonAsync($"{_baseUrl}", customerDto).Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<CustomerDTO>().Result;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
    
    public static CustomerDTO GetCustomer(int id)
    {
        var response = HttpClient.GetAsync($"{_baseUrl}/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<CustomerDTO>().Result;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
    
    public static List<CustomerDTO> GetAllCustomers()
    {
        var response = HttpClient.GetAsync($"{_baseUrl}").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<CustomerDTO>>().Result;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
    
}