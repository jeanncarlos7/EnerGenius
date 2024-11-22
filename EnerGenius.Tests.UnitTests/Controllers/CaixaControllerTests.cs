using Moq;
using Microsoft.AspNetCore.Mvc;
using EnerGenius.Controllers;
using EnerGenius.Models;
using EnerGenius.HttpObjects.Caixa;
using EnerGenius.Services.Interfaces;

namespace EnerGenius.Tests.UnitTests.Controllers
{
    public class CaixaControllerTests
    {
        private readonly Mock<ICaixaService> _mockService;
        private readonly CaixaController _controller;

        public CaixaControllerTests()
        {
            _mockService = new Mock<ICaixaService>();
            _controller = new CaixaController(_mockService.Object);
        }

        [Fact]
        public async Task CreateCaixa_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var caixaInsertRequest = new CaixaInsertRequest
            {
                Nome = "Caixa Teste",
                Saldo = 100.0m,
                UsuarioId = "123"
            };

            _mockService.Setup(service => service.CreateCaixaAsync(It.IsAny<CaixaInsertRequest>()))
                        .ReturnsAsync("1");

            // Act
            var result = await _controller.CreateCaixa(caixaInsertRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetCaixa), createdResult.ActionName);
            Assert.Equal("1", createdResult.RouteValues["id"]);
        }

        [Fact]
        public async Task GetCaixa_ReturnsOkResult()
        {
            // Arrange
            var caixa = new Caixa
            {
                Id = "1",
                Nome = "Caixa Teste",
                Saldo = 100.0m,
                UsuarioId = "123"
            };

            _mockService.Setup(service => service.GetCaixaByIdAsync("1"))
                        .ReturnsAsync(caixa);

            // Act
            var result = await _controller.GetCaixa("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCaixa = Assert.IsType<Caixa>(okResult.Value);
            Assert.Equal(caixa, returnedCaixa);
        }

        [Fact]
        public async Task GetCaixa_ReturnsNotFoundResult_WhenCaixaDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetCaixaByIdAsync("2"))
                        .ReturnsAsync((Caixa)null);

            // Act
            var result = await _controller.GetCaixa("2");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateCaixa_ReturnsNoContentResult()
        {
            // Arrange
            var caixaUpdateRequest = new CaixaUpdateRequest
            {
                Id = "1",
                Nome = "Caixa Atualizada",
                Saldo = 200.0m,
                UsuarioId = "123",
                Ativo = true
            };

            _mockService.Setup(service => service.UpdateCaixaAsync(It.IsAny<CaixaUpdateRequest>()))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateCaixa(caixaUpdateRequest);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCaixa_ReturnsNoContentResult()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteCaixaAsync("1"))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteCaixa("1");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCaixa_ReturnsBadRequest_WhenInvalidId()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteCaixaAsync("invalid"))
                        .ThrowsAsync(new ArgumentException("Id inválido"));

            // Act
            var result = await _controller.DeleteCaixa("invalid");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Id inválido", badRequestResult.Value);
        }
    }
}
