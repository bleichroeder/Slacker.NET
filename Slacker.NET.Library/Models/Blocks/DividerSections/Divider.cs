using Newtonsoft.Json;

namespace Slacker.NET.Library.Models.Blocks.DividerSections
{
    public class Divider : IBlock
    {
        [JsonProperty("type")]
        public string Type => "divider";
    }
}
