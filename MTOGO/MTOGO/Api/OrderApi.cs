using Microsoft.AspNetCore.Mvc;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class OrderApi : ControllerBase
{
    //Get all order
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        string json = await OrderFacade.GetAllOrders();
        return Ok(json);
    }
}