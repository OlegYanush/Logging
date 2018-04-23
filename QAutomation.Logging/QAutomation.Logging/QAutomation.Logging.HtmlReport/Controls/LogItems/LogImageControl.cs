namespace QAutomation.Logging.HtmlReport.Controls
{
    using QAutomation.Logging.HtmlReport.Info;
    using System;
    using System.Xml.Linq;

    public class LogImageControl : LogItemControl
    {
        private static XElement ConfigurateModal(string message, string pathToImage)
        {
            var id = Guid.NewGuid().ToString().Split('-')[0];

            var thumbnail = new XElement("img", new XAttribute("class", "float-right"),
                                          new XAttribute("src", pathToImage),
                                          new XAttribute("width", 100),
                                          new XAttribute("height", 100),
                                          new XAttribute("data-toggle", id));

            var closeButton = new XElement("button", new XAttribute("class", "close-button"),
                                                     new XAttribute("aria-label", "Close"),
                                                     new XAttribute("type", "button"),
                                                     new XAttribute("data-close", string.Empty),
                                                     new XElement("span", new XAttribute("aria-hidden", bool.TrueString), "x"));

            var originalIms = new XElement("img", new XAttribute("src", pathToImage));

            var modal = new XElement("div", new XAttribute("class", "reval small"),
                                            new XAttribute("id", id),
                                            new XAttribute("data-reveal", string.Empty),
                                            new XElement("p", message), originalIms, closeButton);

            return new XElement("div", new XAttribute("class", "auto cell clearfix"), thumbnail, modal);
        }

        private string Message;
        private string PathToImage;

        public LogImageControl() { }
        public LogImageControl(LogAttachmentInfo attachment)
            : base(attachment.Level.ToString(), attachment.TimeStamp)
        {
            Message = attachment.Message;
            PathToImage = attachment.PathToAttachment;
        }

        public override XElement Build()
        {
            var item = base.Build();
            var container = new Div("grid-x grid-margin-x");

            var messageDiv = new Div("large-10 cell");
            messageDiv.Append(new Paragraph(Message));

            container.Append(messageDiv);
            container.Append(ConfigurateModal(Message, PathToImage));

            item.Add(container.Build());
            return item;
        }
    }
}
