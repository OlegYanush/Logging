namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public abstract class Control
    {
        public abstract XElement Build();
    }
}
