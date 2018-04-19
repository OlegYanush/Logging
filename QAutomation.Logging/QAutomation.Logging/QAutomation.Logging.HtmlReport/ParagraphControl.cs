namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class ParagraphControl : Control
    {
        public string Text { get; set; }

        public override XElement Build() => new XElement("p", Text);
    }
}
