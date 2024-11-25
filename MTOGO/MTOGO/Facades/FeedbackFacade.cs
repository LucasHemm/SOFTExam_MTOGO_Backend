using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;

namespace MTOGO.Facades;

public class FeedbackFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();

    //Create feedback
    public static async Task<FeedbackDTO> CreateFeedback(FeedbackDTO feedbackDto)
    {
        var response = await HttpClient.PostAsJsonAsync("http://localhost:5005/api/feedbackapi", feedbackDto);
        response.EnsureSuccessStatusCode();
        var createdFeedback = await response.Content.ReadFromJsonAsync<FeedbackDTO>();
        return createdFeedback;
    }
    
    
    
}