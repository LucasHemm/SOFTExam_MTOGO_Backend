using MTOGO.DTOs.CustomerDTOs;

namespace MTOGO.Interfaces;


public interface ICustomerInterface
{
    Task<CustomerDTO> CreateCustomer(CustomerDTO customerDto);
    Task<CustomerDTO> GetCustomer(int id);
}
