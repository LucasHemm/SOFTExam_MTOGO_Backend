namespace MTOGO.DTOs.CustomerDTOs;

public class PaymentInfoDTO
{
    public int Id { get; set; } //primary key
    public String CardNumber { get; set; }
    public String ExpirationDate { get; set; }


    public PaymentInfoDTO(int id, string cardNumber, string expirationDate)
    {
        Id = id;
        CardNumber = cardNumber;
        ExpirationDate = expirationDate;
    }

    public PaymentInfoDTO()
    {
    }

}