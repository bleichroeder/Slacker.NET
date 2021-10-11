using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.ButtonSections
{
    public class LinkButtonMrkdwnSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "mrkdwn";
        [JsonProperty("text")]
        public string Text { get; set; }

        public LinkButtonMrkdwnSection(string text)
        {
            Text = text;
        }
    }
}
