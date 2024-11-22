using System.ComponentModel.DataAnnotations;
using EnerGenius.Models;

namespace EnerGenius.Tests.UnitTests.Models
{
    public class UsinaModelTests
    {
        [Fact]
        public void CreateUsina_ValidProperties_ShouldCreateInstance()
        {
            // Arrange & Act
            var usina = new Usina
            {
                Id = "64f12bcfe4135b1ff372c7d8", // MongoDB ObjectId-like string
                Nome = "Usina Solar",
                UsuarioId = "507f1f77bcf86cd799439011",
                Endereco = "Rua da Energia, 123",
                Latitude = "-23.550520",
                Longitude = "-46.633308",
                CapacidadeProducaoDiaria = 500.5f,
                ReservaProducao = 200.0f
            };

            // Assert
            Assert.Equal("64f12bcfe4135b1ff372c7d8", usina.Id);
            Assert.Equal("Usina Solar", usina.Nome);
            Assert.Equal("507f1f77bcf86cd799439011", usina.UsuarioId);
            Assert.Equal("Rua da Energia, 123", usina.Endereco);
            Assert.Equal("-23.550520", usina.Latitude);
            Assert.Equal("-46.633308", usina.Longitude);
            Assert.Equal(500.5f, usina.CapacidadeProducaoDiaria);
            Assert.Equal(200.0f, usina.ReservaProducao);
        }

        [Fact]
        public void CreateUsina_MissingNome_ShouldFailValidation()
        {
            // Arrange
            var usina = new Usina
            {
                UsuarioId = "507f1f77bcf86cd799439011",
                ReservaProducao = 200.0f
            };

            // Act
            var validationResults = ValidateModel(usina);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nome"));
        }

        [Fact]
        public void CreateUsina_ExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange
            var usina = new Usina
            {
                Nome = new string('A', 256), // Exceeding MaxLength of 255
                UsuarioId = "507f1f77bcf86cd799439011",
                ReservaProducao = 200.0f
            };

            // Act
            var validationResults = ValidateModel(usina);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nome"));
        }

        [Fact]
        public void CreateUsina_InvalidLatitude_ShouldFailValidation()
        {
            // Arrange
            var usina = new Usina
            {
                Nome = "Usina Teste",
                UsuarioId = "507f1f77bcf86cd799439011",
                Latitude = new string('A', 16), // Exceeding MaxLength of 15
                ReservaProducao = 200.0f
            };

            // Act
            var validationResults = ValidateModel(usina);

            // Assert
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Latitude"));
        }

        [Fact]
        public void CreateUsina_ValidWithOptionalFields_ShouldPassValidation()
        {
            // Arrange
            var usina = new Usina
            {
                Nome = "Usina Hidrelétrica",
                UsuarioId = "507f1f77bcf86cd799439011",
                ReservaProducao = 300.0f
                // Optional fields like Latitude, Longitude, Endereco, and CapacidadeProducaoDiaria are not set
            };

            // Act
            var validationResults = ValidateModel(usina);

            // Assert
            Assert.Empty(validationResults);
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
