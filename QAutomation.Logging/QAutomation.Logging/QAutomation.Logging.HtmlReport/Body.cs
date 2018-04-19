namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Body : Control
    {
        private List<Control> _childControls { get; set; } = new List<Control>();

        public override XElement Build()
        {
            var grid = new XElement("div", new XAttribute("class", "grid-container"));
            _childControls.ForEach(c => grid.Add(c.Build()));

            return new XElement("body", grid);
        }

        public void Add(Control control) => _childControls.Add(control);
    }
}
