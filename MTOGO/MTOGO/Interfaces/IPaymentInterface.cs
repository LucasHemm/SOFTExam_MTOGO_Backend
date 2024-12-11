using MTOGO.DTOs.PaymentDTOs;
using PaymentService.DTOs;

namespace MTOGO.Interfaces;

public interface IPaymentInterface
{
    Task<PaymentDTO> GetPaymentById(int id);
    Task<PaymentDTO> CreatePayment(PaymentRequestDto paymentRequestDto);
}