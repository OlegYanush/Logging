namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Head : Control
    {
        private List<Control> _controls = new List<Control>();

        public Head() { }
        public Head(Title title, params Css[] links)
        {
            Add(title);

            foreach (var link in links)
                Add(link);
        }

        public void Add(Control control) => _controls.Add(control);

        public override XElement Build()
        {
            var head = new XElement("head", new XElement("meta", new XAttribute("charset", "utf-8")));
            _controls.ForEach(c => head.Add(c.Build()));

            return head;
        }
    }
}
