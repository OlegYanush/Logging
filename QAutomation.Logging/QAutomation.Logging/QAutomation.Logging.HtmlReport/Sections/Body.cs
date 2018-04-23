namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Body : Control
    {
        private List<Control> _childControls { get; set; } = new List<Control>();

        public Body() { }
        public Body(params Control[] controls)
        {
            foreach (var control in controls)
                Add(control);
        }

        public override XElement Build()
        {
            var grid = new Div("grid-container");
            _childControls.ForEach(c => grid.Append(c));

            return new XElement("body", grid.Build());
        }

        public void Add(Control control) => _childControls.Add(control);
    }
}
