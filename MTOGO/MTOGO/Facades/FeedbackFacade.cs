using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;

namespace MTOGO.Facades;

public class FeedbackFacade
{
    private static readonly HttpClient HttpClient = new HttpClient();

    //Create feedback
    public static async Task<FeedbackDTO> CreateFeedback(FeedbackDTO feedbackDto)
    {
        FeedbackDTO createdFeedback = null;
        try
        {
            var response = await HttpClient.PostAsJsonAsync("http://orderandfeedback_app:8080/api/feedbackapi", feedbackDto);
            response.EnsureSuccessStatusCode();
            createdFeedback = await response.Content.ReadFromJsonAsync<FeedbackDTO>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        try
        {
            List<FeedbackDTO> agentFeedbacks = await GetFeedbacksByAgentId(createdFeedback.OrderDTO.AgentId);
            List<FeedbackDTO> restaurantFeedbacks = await GetFeedbakcsByRestaurantId(createdFeedback.OrderDTO.RestaurantId);
        
            UpdateRatingDTO agentRatingDto = new UpdateRatingDTO(feedbackDto.OrderDTO.AgentId, agentFeedbacks.Average(feedback => feedback.Agentrating),agentFeedbacks.Count);
            UpdateRatingDTO restaurantRatingDto = new UpdateRatingDTO(feedbackDto.OrderDTO.RestaurantId, restaurantFeedbacks.Average(feedback => feedback.RestaurantRating),restaurantFeedbacks.Count);
        
            await UpdateAgentRating(agentRatingDto);
            await UpdateRestaurantRating(restaurantRatingDto);
            
        }catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        try
        {
            UpdateStatusDTO updateStatusDto = new UpdateStatusDTO(createdFeedback.OrderDTO.Id, "completed");
            await OrderFacade.UpdateOrderStatus(updateStatusDto);
            
        }catch(Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        return createdFeedback;
    }
    
    
    private static async Task<List<FeedbackDTO>>GetFeedbacksByAgentId(int agentId)
    {
        var response = await HttpClient.GetAsync("http://orderandfeedback_app:8080/api/feedbackapi/agent/" + agentId);
        response.EnsureSuccessStatusCode();
        var feedbacks = await response.Content.ReadFromJsonAsync<List<FeedbackDTO>>();
        return feedbacks;
    }
    
    private static async Task<List<FeedbackDTO>> GetFeedbakcsByRestaurantId(int restaurantId)
    {
        var response = await HttpClient.GetAsync("http://orderandfeedback_app:8080/api/feedbackapi/restaurant/" + restaurantId);
        response.EnsureSuccessStatusCode();
        var feedbacks = await response.Content.ReadFromJsonAsync<List<FeedbackDTO>>();
        return feedbacks;
    }
    
    private static async Task UpdateAgentRating(UpdateRatingDTO ratingDto)
    {
        var response = await HttpClient.PutAsJsonAsync("http://agent_app:8080/api/agentapi/rating", ratingDto);
        response.EnsureSuccessStatusCode();
    }
    
    private static async Task UpdateRestaurantRating(UpdateRatingDTO ratingDto)
    {
        var response = await HttpClient.PutAsJsonAsync("http://restaurant_app:8080/api/restaurantapi/rating", ratingDto);
        response.EnsureSuccessStatusCode();
    }
    
}