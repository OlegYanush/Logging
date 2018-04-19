namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class Script : Control
    {
        public string Source { get; set; }

        public Script(string source) { Source = source; }

        public override XElement Build() => new XElement("script", new XAttribute("src", Source), " ");
    }
}
