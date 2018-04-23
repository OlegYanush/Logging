namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class Html : Control
    {
        public Head Head { get; set; }
        public Body Body { get; set; }

        public Html(Head head, Body body)
        {
            Head = head;
            Body = body;
        }

        public override XElement Build() => new XElement("html", Head.Build(), Body.Build());
    }
}
