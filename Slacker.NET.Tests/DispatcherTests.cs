using Slacker.Net.Library;
using Slacker.NET.Library.Models;
using System;
using Xunit;

namespace Slacker.NET.Tests
{
    public class DispatcherTests
    {
        [Fact]
        public void DispatchSimpleMessagePayload()
        {
            Dispatcher.WebhookUri = new Uri("");
            Assert.True(Dispatcher.SendSimpleMessage(new SimpleMessage("TEST PAYLOAD")));
        }

        [Fact]
        public async void DispatchSimpleMessagePayloadAsync()
        {
            Dispatcher.WebhookUri = new Uri("");
            Assert.True(await Dispatcher.SendSimpleMessageAsync(new SimpleMessage("TEST PAYLOAD ASYNC")));
        }

        [Fact]
        public void DispatchBlockKitPayload()
        {
            Dispatcher.WebhookUri = new Uri("");
            BlockPayload payload = new();
            payload.AddHeader("MESSAGE");
            payload.AddImageWithTitle("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png", "Image created with a mobile phone.");
            payload.AddLinkButton("Button Text", "https://www.google.com");
            payload.AddDivider();
            Assert.True(Dispatcher.SendBlockKitPayload(payload));
        }

        [Fact]
        public async void DispatchBlockKitPayloadAsync()
        {
            Dispatcher.WebhookUri = new Uri("");
            BlockPayload payload = new();
            payload.AddHeader("ASYNC MESSAGE");
            payload.AddImageWithTitle("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png", "Image created with a mobile phone.");
            payload.AddLinkButton("Button Text", "https://www.google.com");
            payload.AddDivider();
            Assert.True(await Dispatcher.SendBlockKitPayloadAsync(payload));
        }
    }
}
