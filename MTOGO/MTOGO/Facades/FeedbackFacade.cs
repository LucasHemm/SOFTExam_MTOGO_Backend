using MTOGO.DTOs;
using MTOGO.DTOs.FeedbackDTOs;
using MTOGO.Interfaces;
using System.Net.Http.Json;

namespace MTOGO.Facades
{
    public class FeedbackFacade : BaseFacade, IFeedbackInterface
    {
        private readonly IOrderInterface _orderFacade;
        private readonly IAgentInterface _agentFacade;
        private readonly IRestaurantInterface _restaurantFacade;

        public FeedbackFacade(
            HttpClient httpClient,
            IOrderInterface orderFacade,
            IAgentInterface agentFacade,
            IRestaurantInterface restaurantFacade)
            : base(httpClient)
        {
            _orderFacade = orderFacade;
            _agentFacade = agentFacade;
            _restaurantFacade = restaurantFacade;
        }

        // CreateFeedback
        public async Task<FeedbackDTO> CreateFeedback(FeedbackDTO feedbackDto)
        {
            FeedbackDTO createdFeedback = null;
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", feedbackDto);
                response.EnsureSuccessStatusCode();
                createdFeedback = await response.Content.ReadFromJsonAsync<FeedbackDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating feedback: {e}");
                throw;
            }

            try
            {
                List<FeedbackDTO> agentFeedbacks = await GetFeedbacksByAgentId(createdFeedback.OrderDTO.AgentId);
                List<FeedbackDTO> restaurantFeedbacks = await GetFeedbacksByRestaurantId(createdFeedback.OrderDTO.RestaurantId);
            
                UpdateRatingDTO agentRatingDto = new UpdateRatingDTO(
                    feedbackDto.OrderDTO.AgentId,
                    agentFeedbacks.Average(feedback => feedback.Agentrating),
                    agentFeedbacks.Count
                );

                UpdateRatingDTO restaurantRatingDto = new UpdateRatingDTO(
                    feedbackDto.OrderDTO.RestaurantId,
                    restaurantFeedbacks.Average(feedback => feedback.RestaurantRating),
                    restaurantFeedbacks.Count
                );
            
                await _agentFacade.UpdateAgentRating(agentRatingDto);
                await _restaurantFacade.UpdateRestaurantRating(restaurantRatingDto);
                
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error updating ratings: {e}");
                throw;
            }

            try
            {
                UpdateStatusDTO updateStatusDto = new UpdateStatusDTO(createdFeedback.OrderDTO.Id, "completed");
                await _orderFacade.UpdateOrderStatus(updateStatusDto);
                
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error updating order status: {e}");
                throw;
            }
            
            return createdFeedback;
        }
        
        // GetFeedbacksByAgentId
        public async Task<List<FeedbackDTO>> GetFeedbacksByAgentId(int agentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"agent/{agentId}");
                response.EnsureSuccessStatusCode();
                var feedbacks = await response.Content.ReadFromJsonAsync<List<FeedbackDTO>>();
                return feedbacks;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching feedbacks by agent ID {agentId}: {e}");
                throw;
            }
        }
        
        // GetFeedbakcsByRestaurantId
        private async Task<List<FeedbackDTO>> GetFeedbacksByRestaurantId(int restaurantId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"restaurant/{restaurantId}");
                response.EnsureSuccessStatusCode();
                var feedbacks = await response.Content.ReadFromJsonAsync<List<FeedbackDTO>>();
                return feedbacks;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching feedbacks by restaurant ID {restaurantId}: {e}");
                throw;
            }
        }
    }
}
