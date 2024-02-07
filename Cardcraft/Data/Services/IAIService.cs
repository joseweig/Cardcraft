using Cardcraft.Data.Models;

namespace Cardcraft.Data.Services
{
    public interface IAIService
    {
        Task<Result<string>> GenerateImageAsync(string prompt);
    }
}