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
        /// Send a basic text message asynchronously.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<bool> SendSimpleMessageAsync(SimpleMessage payload, Uri webhookUri)
        {
            return await DispatchAsync(JsonConvert.SerializeObject(payload), webhookUri);
        }

        /// <summary>
        /// Send a basic text message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSimpleMessage(SimpleMessage payload, Uri webhookUri)
        {
            return Dispatch(JsonConvert.SerializeObject(payload), webhookUri);
        }

        /// <summary>
        /// Send a BlockKit payload asynchronously.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static async Task<bool> SendBlockKitPayloadAsync(BlockPayload payload, Uri webhookUri)
        {
            return await DispatchAsync(JsonConvert.SerializeObject(payload), webhookUri);
        }

        /// <summary>
        /// Send a BlockKit payload.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static bool SendBlockKitPayload(BlockPayload payload, Uri webhookUri)
        {
            return Dispatch(JsonConvert.SerializeObject(payload), webhookUri);
        }

        /// <summary>
        /// Send payloads asynchronously.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        private static async Task<bool> DispatchAsync(string payload, Uri webhookUri)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webhookUri);
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
        private static bool Dispatch(string payload, Uri webhookUri)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webhookUri);
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
