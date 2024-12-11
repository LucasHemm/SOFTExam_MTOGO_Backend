using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class FeedbackApi : ControllerBase
{

    private readonly FeedbackFacade _feedbackFacade;
    
    public FeedbackApi(FeedbackFacade feedbackFacade)
    {
        _feedbackFacade = feedbackFacade;
    }
    
    // POST: api/Feedback
    [HttpPost]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDTO feedbackDto)
    {
        try
        {
            FeedbackDTO createdFeedback = await _feedbackFacade.CreateFeedback(feedbackDto);
            return Ok(createdFeedback);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}