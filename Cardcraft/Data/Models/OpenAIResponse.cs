namespace Cardcraft.Data.Models
{
    public class OpenAIResponse
    {
        public long Created { get; set; }
        public List<GeneratedImage> Data { get; set; }
    }

    internal class ImageGenerationRequest
    {
        public string Prompt { get; set; }
        public string Model { get; set; }
    }

    public class GeneratedImage
    {
        public string Url { get; set; }
    }
}
