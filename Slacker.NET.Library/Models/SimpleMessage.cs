using Newtonsoft.Json;

namespace Slacker.NET.Library.Models
{
    /// <summary>
    /// Simple TextMessage payload.
    /// </summary>
    public class SimpleMessage
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        public SimpleMessage(string message)
        {
            Text = message;
        }
    }
}
