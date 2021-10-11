using Newtonsoft.Json;

namespace Slacker.NET.Library.Models
{
    /// <summary>
    /// The BlockKit IBlock interface.
    /// </summary>
    public interface IBlock
    {
        [JsonProperty("type")]
        public string Type { get; }
    }
}
