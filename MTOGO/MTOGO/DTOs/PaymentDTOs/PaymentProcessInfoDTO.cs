namespace MTOGO.DTOs.PaymentDTOs;

public class PaymentProcessInfoDTO
{
    public int Id { get; set; }
    public double RestaurantEarnings { get; set; }
    public double AgentBonus { get; set; }
    public double MTOGOFee{ get; set; }
    
    public PaymentProcessInfoDTO()
    {
    }

    public PaymentProcessInfoDTO(int id, double restaurantEarnings, double agentBonus, double mtogoFee)
    {
        Id = id;
        RestaurantEarnings = restaurantEarnings;
        AgentBonus = agentBonus;
        MTOGOFee = mtogoFee;
    }
}