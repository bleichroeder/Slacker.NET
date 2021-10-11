using Newtonsoft.Json;
using Slacker.NET.Library.Models.Blocks.PlainTextSections;

namespace Slacker.NET.Library.Models.Blocks.ButtonSections
{
    public class LinkButtonAccessory : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "button";
        [JsonProperty("text")]
        public PlainTextSectionTextObject Text { get; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; } = "button-action";
        [JsonProperty("url")]
        public string Url { get; set; }

        public LinkButtonAccessory(string buttonText, string url, bool emoji = true, string value = " ")
        {
            if (string.IsNullOrEmpty(value))
                value = " ";

            Text = new PlainTextSectionTextObject(buttonText, emoji);
            Url = url.Replace(" ", "%20");
            Value = value;
        }
    }
}
