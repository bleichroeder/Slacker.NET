using Newtonsoft.Json;
using Slacker.NET.Library.Models.Blocks.ButtonSections;
using Slacker.NET.Library.Models.Blocks.DividerSections;
using Slacker.NET.Library.Models.Blocks.Headers;
using Slacker.NET.Library.Models.Blocks.ImageSections;
using Slacker.NET.Library.Models.Blocks.MrkdwnSections;
using Slacker.NET.Library.Models.Blocks.PlainTextSections;
using Slacker.NET.Library.Models.Blocks.TextFieldSections;
using System.Collections.Generic;

namespace Slacker.NET.Library.Models
{
    /// <summary>
    /// The BlockKit payload.
    /// </summary>
    public class BlockPayload
    {
        [JsonProperty("blocks")]
        public List<IBlock> Blocks { get; set; }

        public BlockPayload()
        {
            Blocks = new List<IBlock>();
        }

        /// <summary>
        /// Adds a BlockKit Header section to the payload.
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="emoji"></param>
        public void AddHeader(string headerText, bool emoji = true)
        {
            Blocks.Add(new Header(headerText, emoji));
        }

        /// <summary>
        /// Adds a BlockKit PlainText section to the payload.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="emoji"></param>
        public void AddPlainText(string text, bool emoji = true)
        {
            Blocks.Add(new PlainTextSection(text, emoji));
        }

        /// <summary>
        /// Adds a BlockKit Mrkdwn section to the payload.
        /// </summary>
        /// <param name="text"></param>
        public void AddMrkdwn(string text)
        {
            Blocks.Add(new MrkdwnSection(text));
        }

        /// <summary>
        /// Adds a BlockKit TextFields section to the payload.<br />
        /// Accepts a List of BlockKit TextField objects.
        /// </summary>
        /// <param name="textFields"></param>
        public void AddTextFields(List<TextField> textFields = null)
        {
            if (textFields == null)
                textFields = new List<TextField>();

            Blocks.Add(new TextFieldsSection(textFields));
        }

        /// <summary>
        /// Adds a BlockKit LinkButton section to the payload.
        /// </summary>
        /// <param name="buttonText"></param>
        /// <param name="buttonUrl"></param>
        /// <param name="mrkdwnText"></param>
        /// <param name="emoji"></param>
        /// <param name="value"></param>
        public void AddLinkButton(string buttonText, string buttonUrl, string mrkdwnText = null, bool emoji = true, string value = null)
        {
            Blocks.Add(new LinkButtonSection(buttonText, buttonUrl, mrkdwnText, emoji, value));
        }

        /// <summary>
        /// Adds a BlockKit ImageWithTitle section to the payload.
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="imageTitle"></param>
        /// <param name="altText"></param>
        /// <param name="emoji"></param>
        public void AddImageWithTitle(string imageUrl, string imageTitle, string altText = null, bool emoji = true)
        {
            Blocks.Add(new ImageWithTitleSection(imageTitle, imageUrl, altText, emoji));
        }

        /// <summary>
        /// Adds a BlockKit Divider section to the payload.
        /// </summary>
        public void AddDivider()
        {
            Blocks.Add(new Divider());
        }
    }
}
