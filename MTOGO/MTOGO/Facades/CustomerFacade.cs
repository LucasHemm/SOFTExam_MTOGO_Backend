using MTOGO.DTOs.CustomerDTOs;
using MTOGO.Interfaces;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace MTOGO.Facades
{
    public class CustomerFacade : BaseFacade, ICustomerInterface
    {
        public CustomerFacade(HttpClient httpClient) : base(httpClient) { }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customerDto)
        {
            try
            {
                string s = _httpClient.BaseAddress.ToString();
                Console.WriteLine($"Base address: {s}"+ "#############################");
                var response = await _httpClient.PostAsJsonAsync(s, customerDto);
                response.EnsureSuccessStatusCode();
                var createdCustomer = await response.Content.ReadFromJsonAsync<CustomerDTO>();
                return createdCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating customer: {e}");
                throw;
            }
        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}");
                response.EnsureSuccessStatusCode();
                var customer = await response.Content.ReadFromJsonAsync<CustomerDTO>();
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching customer with ID {id}: {e}");
                throw;
            }
        }

    
    }
}