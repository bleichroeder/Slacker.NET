using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slacker.NET.Library.Models.Blocks.TextFieldSections
{
    public class TextFieldsSection : IBlock
    {
        [JsonProperty("type")]
        public string Type =>  "section";

        [JsonProperty("fields")]
        public List<TextField> Fields { get; }

        public TextFieldsSection(List<TextField> textFields)
        {
            Fields = textFields;
        }

        public void AddTextField(string text, bool emoji = true)
        {
            Fields.Add(new TextField(text, emoji));
        }
    }
}
