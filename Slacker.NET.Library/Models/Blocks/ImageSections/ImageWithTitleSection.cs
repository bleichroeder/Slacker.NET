using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.ImageSections
{
    public class ImageWithTitleSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "image";
        [JsonProperty("title")]
        public ImageTitle Text { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        public ImageWithTitleSection(string titleText, string imageUrl, string altText = null, bool emoji = true)
        {
            Text = new ImageTitle(titleText, emoji);
            ImageUrl = imageUrl.Replace(" ", "%20");

            if (string.IsNullOrEmpty(altText))
                altText = " ";
            AltText = altText;
        }
    }
}
