namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class AccordionItem : Control
    {
        private static XElement ConfigurateItem(XElement title, XElement content, bool active = false)
        {
            return new XElement("li", new XAttribute("class", $"accordion-item{(active ? " is-active" : string.Empty)}"),
                                      new XAttribute("data-accordion-item", string.Empty),
                                      title, content);
        }
        private static XElement ConfigurateItemTitle(Control wrappedControl)
        {
            return new XElement("a", new XAttribute("href", "#"),
                                     new XAttribute("class", "accordion-title"),
                                     new XElement(wrappedControl.Build()));
        }
        private static XElement ConfigurateItemContent(Control wrappedControl)
        {
            return new XElement("div", new XAttribute("class", "accordion-content"),
                                       new XAttribute("data-tab-content", string.Empty),
                                       new XElement(wrappedControl.Build()));
        }

        public bool IsActive { get; set; }
        public Control Title { get; set; }
        public Control Content { get; set; }

        public AccordionItem(Control title, Control content, bool active = false)
        {
            Title = title;
            Content = content;
            IsActive = active;
        }

        public override XElement Build()
        {
            var title = ConfigurateItemTitle(Title);
            var content = ConfigurateItemContent(Content);

            return ConfigurateItem(title, content, IsActive);
        }
    }
}
