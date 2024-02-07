namespace Cardcraft.Data.Models
{
    public class OpenAIResponse
    {
        public long Created { get; set; }
        public List<GeneratedImage> Data { get; set; }
    }

    public class GeneratedImage
    {
        public string Url { get; set; }
    }

}
