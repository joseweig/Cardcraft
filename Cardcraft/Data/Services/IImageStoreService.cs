namespace Cardcraft.Data.Services
{
    public interface IImageStoreService
    {
        Task<string> SaveImageFromUrlAsync(string imageUrl, string saveAsFileName);
        Task<bool> DeleteImageAsync(string imageName);
        Task<Stream> GetImageAsync(string imageName);
    }
}