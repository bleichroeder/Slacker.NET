using Slacker.NET.Library.Models;
using System;
using Xunit;

namespace Slacker.NET.Tests
{
    public class DispatcherTests
    {
        private readonly Uri WebhookUri = new ("https://hooks.slack.com/services/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");

        [Fact]
        public void DispatchSimpleMessagePayload()
        {
            Assert.True(new SimpleMessage("TEST PAYLOAD").Send(WebhookUri));
        }

        [Fact]
        public async void DispatchSimpleMessagePayloadAsync()
        {
            Assert.True(await new SimpleMessage("TEST PAYLOAD ASYNC").SendAsync(WebhookUri));
        }

        [Fact]
        public void DispatchBlockKitPayload()
        {
            BlockPayload payload = new();
            payload.AddHeader("MESSAGE");
            payload.AddImageWithTitle("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png", "Image created with a mobile phone.");
            payload.AddLinkButton("Button Text", "https://www.google.com");
            payload.AddDivider();
            Assert.True(payload.Send(WebhookUri));
        }

        [Fact]
        public async void DispatchBlockKitPayloadAsync()
        {
            BlockPayload payload = new();
            payload.AddHeader("ASYNC MESSAGE");
            payload.AddImageWithTitle("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png", "Image created with a mobile phone.");
            payload.AddLinkButton("Button Text", "https://www.google.com");
            payload.AddDivider();
            Assert.True(await payload.SendAsync(WebhookUri));
        }
    }
}
