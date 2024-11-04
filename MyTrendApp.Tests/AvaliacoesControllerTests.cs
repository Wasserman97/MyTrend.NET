
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyTrendApp.Controllers;
using MyTrendApp.Models;
using MyTrendApp.Services;
using Xunit;

namespace MyTrendApp.Tests
{
    public class AvaliacoesControllerTests
    {
        private readonly Mock<IAvaliacaoService> _mockAvaliacaoService;
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AvaliacoesController _controller;

        public AvaliacoesControllerTests()
        {
            _mockAvaliacaoService = new Mock<IAvaliacaoService>();
            _mockAuthService = new Mock<IAuthService>();
            _controller = new AvaliacoesController(_mockAvaliacaoService.Object, _mockAuthService.Object);
        }

        [Fact]
        public async Task AuthenticateAndGetAvaliacao_ReturnsUnauthorized_WhenAuthenticationFails()
        {
            // Arrange
            _mockAuthService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(false);

            // Act
            var result = await _controller.AuthenticateAndGetAvaliacao(1, "invalidUser", "invalidPassword");

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result.Result);
        }

        [Fact]
        public async Task AuthenticateAndGetAvaliacao_ReturnsNotFound_WhenAvaliacaoDoesNotExist()
        {
            // Arrange
            _mockAuthService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(true);
            _mockAvaliacaoService.Setup(service => service.GetAvaliacaoByIdAsync(It.IsAny<int>()))
                                 .ReturnsAsync((Avaliacao)null);

            // Act
            var result = await _controller.AuthenticateAndGetAvaliacao(1, "validUser", "validPassword");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AuthenticateAndGetAvaliacao_ReturnsOk_WhenAvaliacaoExistsAndAuthenticationSucceeds()
        {
            // Arrange
            var avaliacao = new Avaliacao { Id = 1, Comentario = "Good Product" };
            _mockAuthService.Setup(auth => auth.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()))
                            .ReturnsAsync(true);
            _mockAvaliacaoService.Setup(service => service.GetAvaliacaoByIdAsync(It.IsAny<int>()))
                                 .ReturnsAsync(avaliacao);

            // Act
            var result = await _controller.AuthenticateAndGetAvaliacao(1, "validUser", "validPassword");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(avaliacao, okResult.Value);
        }
    }
}
