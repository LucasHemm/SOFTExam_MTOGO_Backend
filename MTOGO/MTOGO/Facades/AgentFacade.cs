using MTOGO.DTOs.AgentDTOs;
using MTOGO.Interfaces;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using MTOGO.DTOs;

namespace MTOGO.Facades
{
    public class AgentFacade : BaseFacade, IAgentInterface
    {
        public AgentFacade(HttpClient httpClient) : base(httpClient) { }

        public async Task<AgentDTO> CreateAgent(AgentDTO agentDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", agentDto);
                response.EnsureSuccessStatusCode();
                var createdAgent = await response.Content.ReadFromJsonAsync<AgentDTO>();
                return createdAgent;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating agent: {e}");
                throw;
            }
        }

        public async Task<AgentDTO> GetAgent(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{id}");
                response.EnsureSuccessStatusCode();
                var agent = await response.Content.ReadFromJsonAsync<AgentDTO>();
                return agent;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error retrieving agent with ID {id}: {e}");
                throw;
            }
        }

        public async Task UpdateAgentRating(UpdateRatingDTO ratingDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("rating", ratingDto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error updating agent rating: {e}");
                throw;
            }
        }
    }
}