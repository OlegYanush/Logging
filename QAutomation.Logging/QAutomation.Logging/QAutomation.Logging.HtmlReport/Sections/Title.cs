namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class Title : Control
    {
        public string Value { get; set; }

        public Title(string value) { Value = value; }

        public override XElement Build() => new XElement("title", Value);
    }
}
