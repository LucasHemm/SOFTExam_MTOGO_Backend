using Moq;
using Moq.Protected;

namespace MTOGOTEST;

public static class HttpClientMock
{
    public static HttpClient GetMockedHttpClient(HttpResponseMessage responseMessage, 
        Func<HttpRequestMessage, bool>? requestMatcher = null)
    {
        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => requestMatcher == null || requestMatcher(req)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(responseMessage)
            .Verifiable();

        return new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("http://test.com/")
        };
    }
}