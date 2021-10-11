using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.PlainTextSections
{
    public class PlainTextSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "section";
        [JsonProperty("text")]
        public PlainTextSectionTextObject Text { get; }

        public PlainTextSection(string text, bool emoji = true)
        {
            Text = new PlainTextSectionTextObject(text, emoji);
        }
    }
}
