namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class Css : Control
    {
        public string Source { get; set; }

        public Css(string href)
        {
            Source = href;
        }

        public override XElement Build() => new XElement("link", new XAttribute("rel", "stylesheet"),new XAttribute("href", Source));
    }
}
