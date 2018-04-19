namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class Accordion : Control
    {
        private static XElement ConfigurateAccordion(bool allowAllClosed = true, bool multiExpanded = true)
        {
            return new XElement("ul", new XAttribute("class", "accordion"),
                                      new XAttribute("data-accordion", string.Empty),
                                      new XAttribute("data-allow-all-closed", allowAllClosed),
                                      new XAttribute("data-multi-expand", multiExpanded));
        }

        public bool AllowAllClosed { get; set; }
        public bool MultiExpanded { get; set; }

        public List<Control> Items { get; set; } = new List<Control>();

        public Accordion(bool allowAllCosed = true, bool multiExpanded = true)
        {
            AllowAllClosed = allowAllCosed;
            MultiExpanded = multiExpanded;
        }

        public override XElement Build()
        {
            var accordion = ConfigurateAccordion(allowAllClosed: AllowAllClosed, multiExpanded: MultiExpanded);
            Items.ForEach(i => accordion.Add(i.Build()));

            return accordion;
        }
    }
}
