using Newtonsoft.Json;
using Slacker.NET.Library.Models;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Slacker.Net.Library
{
    /// <summary>
    /// The Slack message dispatcher.<br />
    /// Allows for dispatch of simple text messages as well as BlockKit payloads.
    /// </summary>
    public static class Dispatcher
    {
        /// <summary>
        /// The Webhook Uri to be used for communicating with your Slack application.
        /// </summary>
        public static Uri WebhookUri { get; set; }

        /// <summary>
        /// Send a basic text message asynchronously.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<bool> SendSimpleMessageAsync(SimpleMessage payload)
        {
            return await DispatchAsync(JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Send a basic text message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSimpleMessage(SimpleMessage payload)
        {
            return Dispatch(JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Send a BlockKit payload asynchronously.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static async Task<bool> SendBlockKitPayloadAsync(BlockPayload payload)
        {
            return await DispatchAsync(JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Send a BlockKit payload.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static bool SendBlockKitPayload(BlockPayload payload)
        {
            return Dispatch(JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Send payloads asynchronously.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private static async Task<bool> DispatchAsync(string payload)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebhookUri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {
                    streamWriter.Write(payload);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

                using var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var response = await streamReader.ReadToEndAsync();

                if (response.Equals(Response.ok.ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        /// <summary>
        /// Send payloads.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private static bool Dispatch(string payload)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebhookUri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(payload);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using var streamReader = new StreamReader(httpResponse.GetResponseStream());

                if (streamReader.ReadToEnd().Equals(Response.ok.ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        private enum Response
        {
            ok
        }
    }
}
