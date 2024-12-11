using MTOGO.Interfaces;

namespace MTOGO.Factories
{
    public interface IFacadeFactory
    {
        IUserInterface GetUserFacade();
        IOrderInterface GetOrderFacade();
        IFeedbackInterface GetFeedbackFacade();
        IPaymentInterface GetPaymentFacade();
        IAgentInterface GetAgentFacade();
        ICustomerInterface GetCustomerFacade();
        IRestaurantInterface GetResFacade();
        
    }
}