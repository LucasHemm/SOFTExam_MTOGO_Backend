using MTOGO.DTOs;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Facades
{
    public class OrderFacade
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<string> GetAllOrders()
        {
            // Define the base address of the API
            string apiUrl = "http://orderandfeedback_app:8080/api/orderapi";

            try
            {
                // Send GET request
                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the content as a string
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Data: {responseData}");
                    return responseData;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return $"Error: Unable to fetch orders. Status Code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return $"Exception: {ex}";
            }
        }

        public static async Task<string> GetOrder(int id)
        {
            // Define the base address of the API
            string apiUrl = $"http://localhost:5005/api/orderapi/{id}";

            try
            {
                // Send GET request
                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the content as a string
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Data: {responseData}");
                    return responseData;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return $"Error: Unable to fetch order. Status Code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return $"Exception: {ex}";
            }
        }

        public static async Task<OrderDTO> CreateOrder(OrderDTO orderDto)
        {
            var response = await HttpClient.PostAsJsonAsync("http://localhost:5005/api/orderapi", orderDto);
            response.EnsureSuccessStatusCode();
            var createdOrder = await response.Content.ReadFromJsonAsync<OrderDTO>();
            return createdOrder;
        }


        public static async Task<OrderDTO> UpdateOrderStatus(UpdateStatusDTO orderDto)
        {
            var response = await HttpClient.PutAsJsonAsync("http://localhost:5005/api/orderapi", orderDto);
            response.EnsureSuccessStatusCode();
            var updatedOrder = await response.Content.ReadFromJsonAsync<OrderDTO>();
            return updatedOrder;
        }
        
        public static async Task<List<OrderDTO>> GetOrdersByStatus(string status)
        {
           var response = await HttpClient.GetAsync($"http://localhost:5005/api/orderapi/status/{status}");
              response.EnsureSuccessStatusCode();
                var orders = await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
                return orders;
        }
        
        public static async Task<OrderDTO> UpdateOrder(UpdateOrderIdsDTO dto)
        {
            var response = await HttpClient.PutAsJsonAsync($"http://localhost:5005/api/orderapi/UpdateIds", dto);
            response.EnsureSuccessStatusCode();
            var updatedOrder = await response.Content.ReadFromJsonAsync<OrderDTO>();
            return updatedOrder;
        }
        
        public static async Task<List<OrderDTO>> GetOrdersByAgentId(int agentId)
        {
            var response = await HttpClient.GetAsync($"http://localhost:5005/api/orderapi/agent/{agentId}");
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
            return orders;
        }
        
        public static async Task<List<OrderDTO>> GetOrdersByCustomerID(int customerId)
        {
            var response = await HttpClient.GetAsync($"http://localhost:5005/api/orderapi/customer/{customerId}");
            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
            return orders;
        }
    }
}