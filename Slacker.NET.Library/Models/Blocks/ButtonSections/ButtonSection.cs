using Newtonsoft.Json;
using Slacker.NET.Library.Models.Blocks.PlainTextSections;

namespace Slacker.NET.Library.Models.Blocks.ButtonSections
{
    public class ButtonSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "button";

        [JsonProperty("text")]
        public PlainTextSectionTextObject Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public ButtonSection(string buttonText, string url, bool emoji = true, string value = null)
        {
            Text = new PlainTextSectionTextObject(buttonText, emoji);
            Url = url;

            if(value != null)
            {
                Value = value;
            }
            else
            {
                Value = " ";
            }
        }
    }
}
