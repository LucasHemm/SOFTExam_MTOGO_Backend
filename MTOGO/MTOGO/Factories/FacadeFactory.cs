using MTOGO.Interfaces;

namespace MTOGO.Factories;

public class FacadeFactory : IFacadeFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FacadeFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUserInterface CreateUserFacade()
    {
        return _serviceProvider.GetRequiredService<IUserInterface>();
    }

    public IOrderInterface CreateOrderFacade()
    {
        return _serviceProvider.GetRequiredService<IOrderInterface>();
    }

    public IFeedbackInterface CreateFeedbackFacade()
    {
        return _serviceProvider.GetRequiredService<IFeedbackInterface>();
    }
    
    public IPaymentInterface CreatePaymentFacade()
    {
        return _serviceProvider.GetRequiredService<IPaymentInterface>();
    }
    
    public IAgentInterface CreateAgentFacade()
    {
        return _serviceProvider.GetRequiredService<IAgentInterface>();
    }
    
    public ICustomerInterface CreateCustomerFacade()
    {
        return _serviceProvider.GetRequiredService<ICustomerInterface>();
    }
    
    public IRestaurantInterface CreateResFacade()
    {
        return _serviceProvider.GetRequiredService<IRestaurantInterface>();
    }
    
    
}