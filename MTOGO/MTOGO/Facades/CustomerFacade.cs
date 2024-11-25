using MTOGO.DTOs.CustomerDTOs;

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
    
}