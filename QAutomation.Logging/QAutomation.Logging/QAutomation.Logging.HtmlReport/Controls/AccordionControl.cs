namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class AccordionControl : Control
    {
        public bool AllowAllClosed { get; set; }
        public bool MultiExpanded { get; set; }

        public List<Control> Items { get; set; } = new List<Control>();

        public AccordionControl(bool allowAllCosed = true, bool multiExpanded = true)
        {
            AllowAllClosed = allowAllCosed;
            MultiExpanded = multiExpanded;
        }

        public override XElement Build()
        {
            var accordion = new XElement("ul", new XAttribute("class", "accordion"),
                                      new XAttribute("data-accordion", string.Empty),
                                      new XAttribute("data-allow-all-closed", AllowAllClosed),
                                      new XAttribute("data-multi-expand", MultiExpanded));

            Items.ForEach(i => accordion.Add(i.Build()));

            return accordion;
        }
    }
}
