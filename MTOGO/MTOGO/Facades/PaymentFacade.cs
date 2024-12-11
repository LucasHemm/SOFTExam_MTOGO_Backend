using MTOGO.DTOs.PaymentDTOs;
using MTOGO.Interfaces;
using PaymentService.DTOs;

namespace MTOGO.Facades
{
    public class PaymentFacade : BaseFacade, IPaymentInterface
    {
        public PaymentFacade(HttpClient httpClient) : base(httpClient) { }

        public async Task<PaymentDTO> GetPaymentById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}");
                response.EnsureSuccessStatusCode();
                var payment = await response.Content.ReadFromJsonAsync<PaymentDTO>();
                return payment;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching payment with ID {id}: {e}");
                throw;
            }
        }

        public async Task<PaymentDTO> CreatePayment(PaymentRequestDto paymentRequestDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", paymentRequestDto);
                response.EnsureSuccessStatusCode();
                var payment = await response.Content.ReadFromJsonAsync<PaymentDTO>();
                return payment;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating payment: {e}");
                throw;
            }
        }
    }
}