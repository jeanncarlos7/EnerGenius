using System.ComponentModel.DataAnnotations;
using EnerGenius.Models;

namespace EnerGenius.Tests.UnitTests.Models
{
    public class CaixaModelTests
    {
        [Fact]
        public void CreateCaixa_ValidProperties_ShouldPassValidation()
        {
            // Arrange
            var caixa = new Caixa
            {
                Nome = "Caixa Teste",
                UsuarioId = "123", // Ajustado para string
                Saldo = 1000.50m
            };

            // Act
            var validationContext = new ValidationContext(caixa);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(caixa, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "A validação deveria passar para propriedades válidas.");
        }

        [Fact]
        public void CreateCaixa_MissingNome_ShouldFailValidation()
        {
            // Arrange
            var caixa = new Caixa
            {
                UsuarioId = "123", // Ajustado para string
                Saldo = 1000.50m
            };

            // Act
            var validationContext = new ValidationContext(caixa);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(caixa, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar sem o campo Nome.");
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nome"));
        }

        [Fact]
        public void CreateCaixa_NomeExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange
            var caixa = new Caixa
            {
                Nome = new string('A', 256), // Excede o limite de 255 caracteres
                UsuarioId = "123", // Ajustado para string
                Saldo = 1000.50m
            };

            // Act
            var validationContext = new ValidationContext(caixa);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(caixa, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid, "A validação deveria falhar se o Nome exceder o comprimento máximo.");
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Nome"));
        }

        [Fact]
        public void CreateCaixa_NullSaldo_ShouldPassValidation()
        {
            // Arrange
            var caixa = new Caixa
            {
                Nome = "Caixa Teste",
                UsuarioId = "123", // Ajustado para string
                Saldo = null
            };

            // Act
            var validationContext = new ValidationContext(caixa);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(caixa, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid, "A validação deveria passar quando o Saldo for nulo.");
        }
    }
}
