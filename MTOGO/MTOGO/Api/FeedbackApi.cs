using Microsoft.AspNetCore.Mvc;
using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Facades;

namespace MTOGO.Api;
[ApiController]
[Route("api/[controller]")]
public class FeedbackApi : ControllerBase
{

    
    // POST: api/Feedback
    [HttpPost]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDTO feedbackDto)
    {
        try
        {
            FeedbackDTO createdFeedback = await FeedbackFacade.CreateFeedback(feedbackDto);
            return Ok(createdFeedback);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}