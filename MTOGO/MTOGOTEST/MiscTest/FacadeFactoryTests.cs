// File: FacadeFactoryTests.cs

using Moq;
using MTOGO.Factories;
using MTOGO.Interfaces;

namespace MTOGOTEST.MiscTest
{
    public class FacadeFactoryTests
    {
        private readonly Mock<IServiceProvider> _mockServiceProvider;
        private readonly FacadeFactory _factory;

        // Mock facades
        private readonly Mock<IUserInterface> _mockUserFacade;
        private readonly Mock<IOrderInterface> _mockOrderFacade;
        private readonly Mock<IFeedbackInterface> _mockFeedbackFacade;
        private readonly Mock<IPaymentInterface> _mockPaymentFacade;
        private readonly Mock<IAgentInterface> _mockAgentFacade;
        private readonly Mock<ICustomerInterface> _mockCustomerFacade;
        private readonly Mock<IRestaurantInterface> _mockRestaurantFacade;

        public FacadeFactoryTests()
        {
            // Initialize the mock IServiceProvider
            _mockServiceProvider = new Mock<IServiceProvider>();

            // Initialize mocks for each facade interface
            _mockUserFacade = new Mock<IUserInterface>();
            _mockOrderFacade = new Mock<IOrderInterface>();
            _mockFeedbackFacade = new Mock<IFeedbackInterface>();
            _mockPaymentFacade = new Mock<IPaymentInterface>();
            _mockAgentFacade = new Mock<IAgentInterface>();
            _mockCustomerFacade = new Mock<ICustomerInterface>();
            _mockRestaurantFacade = new Mock<IRestaurantInterface>();

            // Setup the IServiceProvider to return the corresponding mock when requested
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IUserInterface)))
                .Returns(_mockUserFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IOrderInterface)))
                .Returns(_mockOrderFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IFeedbackInterface)))
                .Returns(_mockFeedbackFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IPaymentInterface)))
                .Returns(_mockPaymentFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IAgentInterface)))
                .Returns(_mockAgentFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(ICustomerInterface)))
                .Returns(_mockCustomerFacade.Object);
            _mockServiceProvider.Setup(sp => sp.GetService(typeof(IRestaurantInterface)))
                .Returns(_mockRestaurantFacade.Object);

            // Instantiate the FacadeFactory with the mocked IServiceProvider
            _factory = new FacadeFactory(_mockServiceProvider.Object);
        }

        [Fact]
        public void GetUserFacade_ShouldReturnUserFacade()
        {
            // Act
            var userFacade = _factory.GetUserFacade();

            // Assert
            Assert.NotNull(userFacade);
            Assert.Equal(_mockUserFacade.Object, userFacade);

            // Verify that IServiceProvider.GetService was called once with IUserInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IUserInterface)), Times.Once);
        }

        [Fact]
        public void GetOrderFacade_ShouldReturnOrderFacade()
        {
            // Act
            var orderFacade = _factory.GetOrderFacade();

            // Assert
            Assert.NotNull(orderFacade);
            Assert.Equal(_mockOrderFacade.Object, orderFacade);

            // Verify that IServiceProvider.GetService was called once with IOrderInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IOrderInterface)), Times.Once);
        }

        [Fact]
        public void GetFeedbackFacade_ShouldReturnFeedbackFacade()
        {
            // Act
            var feedbackFacade = _factory.GetFeedbackFacade();

            // Assert
            Assert.NotNull(feedbackFacade);
            Assert.Equal(_mockFeedbackFacade.Object, feedbackFacade);

            // Verify that IServiceProvider.GetService was called once with IFeedbackInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IFeedbackInterface)), Times.Once);
        }

        [Fact]
        public void GetPaymentFacade_ShouldReturnPaymentFacade()
        {
            // Act
            var paymentFacade = _factory.GetPaymentFacade();

            // Assert
            Assert.NotNull(paymentFacade);
            Assert.Equal(_mockPaymentFacade.Object, paymentFacade);

            // Verify that IServiceProvider.GetService was called once with IPaymentInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IPaymentInterface)), Times.Once);
        }

        [Fact]
        public void GetAgentFacade_ShouldReturnAgentFacade()
        {
            // Act
            var agentFacade = _factory.GetAgentFacade();

            // Assert
            Assert.NotNull(agentFacade);
            Assert.Equal(_mockAgentFacade.Object, agentFacade);

            // Verify that IServiceProvider.GetService was called once with IAgentInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IAgentInterface)), Times.Once);
        }

        [Fact]
        public void GetCustomerFacade_ShouldReturnCustomerFacade()
        {
            // Act
            var customerFacade = _factory.GetCustomerFacade();

            // Assert
            Assert.NotNull(customerFacade);
            Assert.Equal(_mockCustomerFacade.Object, customerFacade);

            // Verify that IServiceProvider.GetService was called once with ICustomerInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(ICustomerInterface)), Times.Once);
        }

        [Fact]
        public void GetResFacade_ShouldReturnRestaurantFacade()
        {
            // Act
            var restaurantFacade = _factory.GetResFacade();

            // Assert
            Assert.NotNull(restaurantFacade);
            Assert.Equal(_mockRestaurantFacade.Object, restaurantFacade);

            // Verify that IServiceProvider.GetService was called once with IRestaurantInterface
            _mockServiceProvider.Verify(sp => sp.GetService(typeof(IRestaurantInterface)), Times.Once);
        }
    }
}
