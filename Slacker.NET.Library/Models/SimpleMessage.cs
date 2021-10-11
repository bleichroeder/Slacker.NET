using Newtonsoft.Json;
using Slacker.Net.Library;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Sends payload using specified webhook Uri synchronously.
        /// </summary>
        /// <param name="webhookUri"></param>
        /// <returns></returns>
        public bool Send(Uri webhookUri)
        {
            return Dispatcher.SendSimpleMessage(this, webhookUri);
        }

        /// <summary>
        /// Sends payload using specified webhook Uri asynchronously.
        /// </summary>
        /// <param name="webhookUri"></param>
        /// <returns></returns>
        public async Task<bool> SendAsync(Uri webhookUri)
        {
            return await Dispatcher.SendSimpleMessageAsync(this, webhookUri);
        }
    }
}
