using Newtonsoft.Json;
using Slacker.NET.Library.Models;
using System;
using Xunit;

namespace Slacker.NET.Tests
{
    public class BlockKitTests
    {
        [Fact]
        public void CreateImageSectionWithoutTitle()
        {
            BlockPayload payload = new ();
            payload.AddImageWithTitle("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Image_created_with_a_mobile_phone.png/220px-Image_created_with_a_mobile_phone.png", "Image created with a mobile phone.");

            string serialized = JsonConvert.SerializeObject(payload, Formatting.Indented);
        }

        [Fact]
        public void CreateButtonWithNoMrkdwnText()
        {
            BlockPayload payload = new();
            payload.AddLinkButton("Button Text", "https://www.google.com");

            string serialized = JsonConvert.SerializeObject(payload, Formatting.Indented);
        }
    }
}
