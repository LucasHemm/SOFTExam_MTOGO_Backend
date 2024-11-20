namespace MTOGO.Facades
{
    public class OrderFacade
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<string> GetAllOrders()
        {
            // Define the base address of the API
            string apiUrl = "http://localhost:5005/api/orderapi";

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
    }
}