using System.ComponentModel.DataAnnotations;
using EnerGenius.Models;

namespace EnerGenius.Tests.UnitTests.Models
{
    public class UsuarioTests
    {
        [Fact]
        public void CreateUsuario_ValidProperties_ShouldCreateInstance()
        {
            // Arrange
            var dataAtual = DateTime.Now;

            // Act
            var usuario = new Usuario
            {
                Id = "64f12bcfe4135b1ff372c7d8",
                Email = "test@example.com",
                Pwd = "password",
                Nome = "Test User"
            };

            // Assert
            Assert.Equal("64f12bcfe4135b1ff372c7d8", usuario.Id);
            Assert.Equal("test@example.com", usuario.Email);
            Assert.Equal("password", usuario.Pwd);
            Assert.Equal("Test User", usuario.Nome);
        }

        [Fact]
        public void CreateUsuario_MissingEmail_ShouldThrowValidationError()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = "64f12bcfe4135b1ff372c7d8",
                Pwd = "password",
                Nome = "Test User"
            };

            // Act
            var validationContext = new ValidationContext(usuario);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(usuario, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Email"));
        }

        [Fact]
        public void CreateUsuario_InvalidEmail_ShouldThrowValidationError()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = "64f12bcfe4135b1ff372c7d8",
                Email = "invalid-email fhoiuahnfoiasjifojasiofjasofhaoshfasihfaiosfcioasnfinasckvmascmasasodfoajfdvf",
                Pwd = "password",
                Nome = "Test User"
            };

            // Act
            var validationContext = new ValidationContext(usuario);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(usuario, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Email"));
        }

        [Fact]
        public void CreateUsuario_MissingNome_ShouldThrowValidationError()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = "64f12bcfe4135b1ff372c7d8",
                Email = "test@example.com",
                Pwd = "password"
            };

            // Act
            var validationContext = new ValidationContext(usuario);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(usuario, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nome"));
        }
    }
}
