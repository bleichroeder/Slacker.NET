using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.MrkdwnSections
{
    public class MrkdwnSectionTextObject : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "mrkdwn";
        [JsonProperty("text")]
        public string Text { get; set; }

        public MrkdwnSectionTextObject(string text)
        {
            Text = text;
        }
    }
}
