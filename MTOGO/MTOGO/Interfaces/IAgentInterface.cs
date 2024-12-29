using MTOGO.DTOs;
using MTOGO.DTOs.AgentDTOs;
using MTOGO.DTOs.FeedbackDTOs;

namespace MTOGO.Interfaces;


public interface IAgentInterface
{
    Task<AgentDTO> CreateAgent(AgentDTO agentDto);
    Task<AgentDTO> GetAgent(int id);
    Task UpdateAgentRating(UpdateRatingDTO ratingDto);
    
}
