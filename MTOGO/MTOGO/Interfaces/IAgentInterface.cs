using MTOGO.DTOs.AgentDTOs;

namespace MTOGO.Interfaces;


public interface IAgentInterface
{
    AgentDTO CreateAgent(AgentDTO agentDto);
    AgentDTO GetAgent(int id);
}
