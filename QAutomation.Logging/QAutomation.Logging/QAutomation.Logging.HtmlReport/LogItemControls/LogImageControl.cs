namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Xml.Linq;

    public class LogImageControl : LogItemControl
    {
        private static XElement ConfigurateContainer() => new XElement("div", new XAttribute("class", "grid-x grid-margin-x"));

        private static XElement ConfigurateReveal(string message, string pathToImage)
        {
            var id = Guid.NewGuid().ToString().Split('-')[0];

            var img = new XElement("img", new XAttribute("class", "float-right"),
                                          new XAttribute("src", pathToImage),
                                          new XAttribute("width", 100),
                                          new XAttribute("height", 100),
                                          new XAttribute("data-toggle", id));

            var closeButton = new XElement("button", new XAttribute("class", "close-button"),
                                                     new XAttribute("aria-label", "Close"),
                                                     new XAttribute("type", "button"),
                                                     new XAttribute("data-close", string.Empty),
                                                     new XElement("span", new XAttribute("aria-hidden", bool.TrueString), "x"));

            var revalImg = new XElement("img", new XAttribute("src", pathToImage));

            var reval = new XElement("div", new XAttribute("class", "reval small"),
                                            new XAttribute("id", id),
                                            new XAttribute("data-reveal", string.Empty),
                                            new XElement("p", message), revalImg, closeButton);

            return new XElement("div", new XAttribute("class", "auto cell clearfix"), img, reval);
        }

        private readonly string _pathToImage;
        private readonly string _message;

        public LogImageControl(string level, DateTime timeStamp, string message, string pathToImage)
            : base(level, timeStamp)
        {
            _pathToImage = pathToImage;
            _message = message;
        }

        public override XElement Build()
        {
            var logItem = base.Build();

            var container = ConfigurateContainer();

            container.Add(new XElement("div", new XAttribute("class", "large-10 cell"), new XElement("p", _message)));
            container.Add(ConfigurateReveal(_message, _pathToImage));

            logItem.Add(container);
            return logItem;
        }
    }
}
