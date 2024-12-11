using MTOGO.Interfaces;

namespace MTOGO.Factories;

public class FacadeFactory : IFacadeFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FacadeFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUserInterface GetUserFacade()
    {
        return _serviceProvider.GetRequiredService<IUserInterface>();
    }

    public IOrderInterface GetOrderFacade()
    {
        return _serviceProvider.GetRequiredService<IOrderInterface>();
    }

    public IFeedbackInterface GetFeedbackFacade()
    {
        return _serviceProvider.GetRequiredService<IFeedbackInterface>();
    }
    
    public IPaymentInterface GetPaymentFacade()
    {
        return _serviceProvider.GetRequiredService<IPaymentInterface>();
    }
    
    public IAgentInterface GetAgentFacade()
    {
        return _serviceProvider.GetRequiredService<IAgentInterface>();
    }
    
    public ICustomerInterface GetCustomerFacade()
    {
        Console.WriteLine(_serviceProvider);
        Console.WriteLine(_serviceProvider.GetRequiredService<ICustomerInterface>());
        return _serviceProvider.GetRequiredService<ICustomerInterface>();
    }
    
    public IRestaurantInterface GetResFacade()
    {
        return _serviceProvider.GetRequiredService<IRestaurantInterface>();
    }
    
    
}