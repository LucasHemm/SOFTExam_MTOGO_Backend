using MTOGO.DTOs;
using OrderAndFeedbackService.DTOs;

namespace MTOGO.Interfaces;

public interface IOrderInterface
{
    Task<string> GetAllOrders();
    Task<string> GetOrder(int id);
    Task<OrderDTO> CreateOrder(OrderDTO orderDto);
    Task<OrderDTO> UpdateOrderStatus(UpdateStatusDTO orderDto);
    Task<List<OrderDTO>> GetOrdersByStatus(string status);
    Task<OrderDTO> UpdateOrder(UpdateOrderIdsDTO dto);
    Task<List<OrderDTO>> GetOrdersByAgentId(int agentId);
    Task<List<OrderDTO>> GetOrdersByCustomerID(int customerId);
}