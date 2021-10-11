using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.ButtonSections
{
    public class LinkButtonSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "section";

        [JsonProperty("text")]
        public LinkButtonMrkdwnSection Text { get; set; }

        [JsonProperty("accessory")]
        public LinkButtonAccessory Accessory { get; set; }

        public LinkButtonSection(string buttonText, string url, string mrkdwnText = null, bool emoji = true, string value = null)
        {
            Text = new LinkButtonMrkdwnSection(mrkdwnText);
            Accessory = new LinkButtonAccessory(buttonText, url, emoji, value);
        }
    }
}
