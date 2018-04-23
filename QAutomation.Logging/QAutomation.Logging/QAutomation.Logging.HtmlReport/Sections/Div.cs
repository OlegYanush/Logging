namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Div : Control
    {
        private XElement _divElement;

        public Queue<object> _queue = new Queue<object>();

        public Div(string @class)
        {
            _divElement = new XElement("div", new XAttribute("class", @class));
        }

        public void SetAttribute(string name, string value) => _divElement.Add(new XElement(name, value));
        public void Append(XElement element) => _queue.Enqueue(element);
        public void Append(Control control) => _queue.Enqueue(control);

        public void Append(params XElement[] elements)
        {
            foreach (var element in elements)
                _divElement.Add(element);
        }

        public override XElement Build()
        {
            while (_queue.Count != 0)
            {
                var item = _queue.Dequeue();

                switch (item)
                {
                    case XElement xElement:
                        _divElement.Add(xElement);
                        continue;
                    case Control control:
                        _divElement.Add(control.Build());
                        continue;
                }
            }
            return _divElement;
        }
    }
}
