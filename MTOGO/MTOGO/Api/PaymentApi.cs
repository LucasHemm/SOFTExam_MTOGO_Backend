using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.PaymentDTOs;
using MTOGO.Facades;
using PaymentService.DTOs;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class PaymentApi : ControllerBase
{
    private readonly PaymentFacade _paymentFacade;
    
    public PaymentApi(PaymentFacade paymentFacade)
    {
        _paymentFacade = paymentFacade;
    }
    
    //Get: api/Payment
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payments = await _paymentFacade.GetPaymentById(id);
        return Ok(payments);
    }
    
    // POST: api/Payment
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDto request)
    {
        try
        {
            PaymentDTO payment = await _paymentFacade.CreatePayment(request);
            return Ok(payment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}