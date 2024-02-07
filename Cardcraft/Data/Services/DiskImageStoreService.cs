
namespace Cardcraft.Data.Services
{
    public class DiskImageStoreService : IImageStoreService
    {
        private readonly string _imagesFolder;

        public DiskImageStoreService(IWebHostEnvironment env)
        {
            _imagesFolder = Path.Combine(env.WebRootPath, "cardImages");
            if (!Directory.Exists(_imagesFolder))
            {
                Directory.CreateDirectory(_imagesFolder);
            }
        }

        public async Task<string> SaveImageFromUrlAsync(string imageUrl, string saveAsFileName)
        {
            var client = new HttpClient();
            using (var response = await client.GetAsync(imageUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var imageBytes = await response.Content.ReadAsByteArrayAsync();
                    var filePath = Path.Combine(_imagesFolder, saveAsFileName);
                    await File.WriteAllBytesAsync(filePath, imageBytes);
                    return $"/cardImages/{saveAsFileName}";
                }
                else
                {
                    throw new Exception("Failed to download the image.");
                }
            }
        }

        public async Task<bool> DeleteImageAsync(string imageName)
        {
            var filePath = Path.Combine(_imagesFolder, imageName);
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return true;
                }
                catch (Exception ex)
                {
                    // TODO: throw the exceptions
                    Console.Error.WriteLine($"Error deleting image: {ex.Message}");
                    return false;
                }
            }
            return false;
        }

        public async Task<Stream> GetImageAsync(string imageName)
        {
            var filePath = Path.Combine(_imagesFolder, imageName);
            return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }

}
