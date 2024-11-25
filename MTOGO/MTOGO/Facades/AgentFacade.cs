using MTOGO.DTOs.AgentDTOs;

namespace MTOGO.Facades;

public class AgentFacade
{
    
    private static readonly HttpClient HttpClient = new HttpClient();
    private static readonly string _baseUrl = "http://localhost:5037/api/agentapi";
    
    public static AgentDTO CreateAgent(AgentDTO agentDto)
    {
        var response = HttpClient.PostAsJsonAsync($"{_baseUrl}", agentDto).Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<AgentDTO>().Result;
    }
}