using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.TextFieldSections
{
    public class TextField : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "plain_text";
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("emoji")]
        public bool Emoji { get; set; } = true;

        public TextField(string text, bool emoji = true)
        {
            Text = text;
            Emoji = emoji;
        }
    }
}
