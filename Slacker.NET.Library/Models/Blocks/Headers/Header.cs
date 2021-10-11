using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.Headers
{
    public class Header : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "header";
        [JsonProperty("text")]
        public HeaderTextObject Text { get; }

        public Header(string headerText, bool emoji = true)
        {
            Text = new HeaderTextObject(headerText, emoji);
        }
    }
}
