using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.ImageSections
{
    public class ImageTitle : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "plain_text";
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("emoji")]
        public bool Emoji { get; set; } = true;

        public ImageTitle(string titleText, bool emoji = true)
        {
            Text = titleText;
            Emoji = emoji;
        }
    }
}
