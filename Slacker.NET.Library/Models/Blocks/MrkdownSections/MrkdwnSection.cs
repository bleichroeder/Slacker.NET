using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.MrkdwnSections
{
    public class MrkdwnSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "section";
        [JsonProperty("text")]
        public MrkdwnSectionTextObject Text { get; }

        public MrkdwnSection(string text)
        {
            Text = new MrkdwnSectionTextObject(text);
        }
    }
}
