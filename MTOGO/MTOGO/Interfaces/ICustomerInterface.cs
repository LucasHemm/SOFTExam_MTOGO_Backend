using MTOGO.DTOs.CustomerDTOs;

namespace MTOGO.Interfaces;


public interface ICustomerInterface
{
    CustomerDTO CreateCustomer(CustomerDTO customerDto);
    CustomerDTO GetCustomer(int id);
}
