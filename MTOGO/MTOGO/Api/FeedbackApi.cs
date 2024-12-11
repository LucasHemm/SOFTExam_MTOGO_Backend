using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class FeedbackApi : ControllerBase
{

    private readonly IFacadeFactory _facadeFactory;
    
    public FeedbackApi(IFacadeFactory factory)
    {
        _facadeFactory = factory;
    }
   
    
    // POST: api/Feedback
    [HttpPost]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDTO feedbackDto)
    {
        try
        {
            IFeedbackInterface feedbackFacade = _facadeFactory.GetFeedbackFacade();
            FeedbackDTO createdFeedback = await feedbackFacade.CreateFeedback(feedbackDto);
            return Ok(createdFeedback);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}