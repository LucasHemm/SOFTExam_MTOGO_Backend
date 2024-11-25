using MTOGO.DTOs.RestaurantDTOs;

namespace MTOGO.DTOs.CustomerDTOs;

public class CustomerDTO
{
    public int Id { get; set; } //primary key
    public string Email { get; set; }
    public PaymentInfoDTO PaymentInfoDTO { get; set; }
    public AddressDTO AddressDTO { get; set; }


    public CustomerDTO(int id, string email, PaymentInfoDTO paymentInfoDto, AddressDTO addressDto)
    {
        Id = id;
        Email = email;
        PaymentInfoDTO = paymentInfoDto;
        AddressDTO = addressDto;
    }

    public CustomerDTO()
    {
    }

}