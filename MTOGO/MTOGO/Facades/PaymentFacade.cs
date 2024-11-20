using MTOGO.DTOs.PaymentDTOs;
using PaymentService.DTOs;

namespace MTOGO.Facades;

public class PaymentFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task<PaymentDTO> GetPaymentById(int id)
    {
        var response = await HttpClient.GetAsync("http://localhost:5036/api/paymentapi/"+id);
        response.EnsureSuccessStatusCode();
        var payments = await response.Content.ReadFromJsonAsync<PaymentDTO>();
        return payments;
    }
    
    public static async Task<PaymentDTO> CreatePayment(PaymentRequestDto paymentRequestDto)
    {
        var response = await HttpClient.PostAsJsonAsync("http://localhost:5036/api/paymentapi", paymentRequestDto);
        response.EnsureSuccessStatusCode();
        var payments = await response.Content.ReadFromJsonAsync<PaymentDTO>();
        return payments;
    }
}