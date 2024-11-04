
using System.Net.Http;
using System.Threading.Tasks;
using MyTrendApp.Services;
using Xunit;
using Moq;
using Moq.Protected;
using System.Net;

namespace MyTrendApp.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task AuthenticateAsync_ReturnsTrue_WhenCredentialsAreValid()
        {
            // Arrange
            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            httpClientHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", 
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            var httpClient = new HttpClient(httpClientHandlerMock.Object);
            var authService = new AuthService(httpClient);

            // Act
            var result = await authService.AuthenticateAsync("validUser", "validPassword");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AuthenticateAsync_ReturnsFalse_WhenCredentialsAreInvalid()
        {
            // Arrange
            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            httpClientHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", 
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized
                });

            var httpClient = new HttpClient(httpClientHandlerMock.Object);
            var authService = new AuthService(httpClient);

            // Act
            var result = await authService.AuthenticateAsync("invalidUser", "invalidPassword");

            // Assert
            Assert.False(result);
        }
    }
}
