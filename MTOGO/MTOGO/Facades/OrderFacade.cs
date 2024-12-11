using MTOGO.DTOs;
using OrderAndFeedbackService.DTOs;
using MTOGO.Interfaces;
using System.Net.Http.Json;

namespace MTOGO.Facades
{
    public class OrderFacade : BaseFacade, IOrderInterface
    {
        public OrderFacade(HttpClient httpClient) : base(httpClient) { }

        public async Task<string> GetAllOrders()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetOrder(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDto)
        {
            var response = await _httpClient.PostAsJsonAsync("", orderDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrderDTO>();
        }

        public async Task<OrderDTO> UpdateOrderStatus(UpdateStatusDTO orderDto)
        {
            var response = await _httpClient.PutAsJsonAsync("", orderDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrderDTO>();
        }
        
        public async Task<List<OrderDTO>> GetOrdersByStatus(string status)
        {
            var response = await _httpClient.GetAsync($"status/{status}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
        }

        public async Task<OrderDTO> UpdateOrder(UpdateOrderIdsDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync("UpdateIds", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrderDTO>();
        }

        public async Task<List<OrderDTO>> GetOrdersByAgentId(int agentId)
        {
            var response = await _httpClient.GetAsync($"agent/{agentId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
        }

        public async Task<List<OrderDTO>> GetOrdersByCustomerID(int customerId)
        {
            var response = await _httpClient.GetAsync($"customer/{customerId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
        }
    }
}
