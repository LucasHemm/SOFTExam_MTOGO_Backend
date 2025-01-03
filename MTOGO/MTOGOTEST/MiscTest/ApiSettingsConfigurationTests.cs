// File: ApiSettingsConfigurationTests.cs

using Microsoft.Extensions.Configuration;
using MTOGO.Configurations;

namespace MTOGOTEST.MiscTest
{
    public class ApiSettingsConfigurationTests
    {
        [Fact]
        public void ApiSettings_ShouldBindConfigurationCorrectly()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"ApiSettings:ResUrl", "http://localhost:5000/res"},
                {"ApiSettings:OrderUrl", "http://localhost:5000/order"},
                {"ApiSettings:FeedbackUrl", "http://localhost:5000/feedback"},
                {"ApiSettings:UserUrl", "http://localhost:5000/user"},
                {"ApiSettings:PaymentUrl", "http://localhost:5000/payment"},
                {"ApiSettings:AgentUrl", "http://localhost:5000/agent"},
                {"ApiSettings:CustomerUrl", "http://localhost:5000/customer"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            // Act
            var apiSettings = new ApiSettings();
            configuration.GetSection("ApiSettings").Bind(apiSettings);

            // Assert
            Assert.Equal("http://localhost:5000/res", apiSettings.ResUrl);
            Assert.Equal("http://localhost:5000/order", apiSettings.OrderUrl);
            Assert.Equal("http://localhost:5000/feedback", apiSettings.FeedbackUrl);
            Assert.Equal("http://localhost:5000/user", apiSettings.UserUrl);
            Assert.Equal("http://localhost:5000/payment", apiSettings.PaymentUrl);
            Assert.Equal("http://localhost:5000/agent", apiSettings.AgentUrl);
            Assert.Equal("http://localhost:5000/customer", apiSettings.CustomerUrl);
        }
    }
}