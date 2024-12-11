using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs.PaymentDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;
using PaymentService.DTOs;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class PaymentApi : ControllerBase
{
    private readonly IFacadeFactory _facadeFactory;
    
    public PaymentApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
    
    //Get: api/Payment
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        IPaymentInterface paymentFacade = _facadeFactory.GetPaymentFacade();
        var payments = await paymentFacade.GetPaymentById(id);
        return Ok(payments);
    }
    
    // POST: api/Payment
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDto request)
    {
        try
        {
            IPaymentInterface paymentFacade = _facadeFactory.GetPaymentFacade();
            PaymentDTO payment = await paymentFacade.CreatePayment(request);
            return Ok(payment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}