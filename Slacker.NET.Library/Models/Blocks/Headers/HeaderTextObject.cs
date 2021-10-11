using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.Headers
{
    public class HeaderTextObject : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "plain_text";
        [JsonProperty("text")]
        public string Text { get; }
        [JsonProperty("emoji")]
        public bool Emoji { get; set; } = true;

        public HeaderTextObject(string text, bool emoji = true)
        {
            Text = text;
            Emoji = emoji;
        }
    }
}
