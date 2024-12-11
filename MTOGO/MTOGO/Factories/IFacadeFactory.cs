using MTOGO.Interfaces;

namespace MTOGO.Factories
{
    public interface IFacadeFactory
    {
        IUserInterface CreateUserFacade();
        IOrderInterface CreateOrderFacade();
        IFeedbackInterface CreateFeedbackFacade();
        IPaymentInterface CreatePaymentFacade();
        IAgentInterface CreateAgentFacade();
        ICustomerInterface CreateCustomerFacade();
        IRestaurantInterface CreateResFacade();
        
    }
}