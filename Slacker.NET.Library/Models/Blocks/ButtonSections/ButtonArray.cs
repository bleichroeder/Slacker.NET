using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slacker.NET.Library.Models.Blocks.ButtonSections
{
    public class ButtonArray : IBlock
    {
        [JsonProperty("type")]
        public string Type => "actions";

        [JsonProperty("elements")]
        public List<ButtonSection> Elements { get; set; } = new List<ButtonSection>();

        public ButtonArray(List<ButtonSection> buttons = null)
        {
            if (buttons != null)
                Elements = buttons;
        }

        public void AddButton(string text, string url, bool emoji = true, string value = null)
        {
            Elements.Add(new ButtonSection(text, url, emoji, value));
        }
    }
}
