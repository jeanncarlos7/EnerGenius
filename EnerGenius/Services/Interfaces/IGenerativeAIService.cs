namespace EnerGenius.Services.Interfaces
{
    public interface IGenerativeAIService
    {
        Task<string> GenerateText(string prompt);
    }
}
