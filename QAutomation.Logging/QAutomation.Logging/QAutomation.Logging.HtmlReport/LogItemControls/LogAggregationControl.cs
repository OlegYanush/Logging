namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class LogAggregationControl : LogItemControl
    {
        private static XElement ConfigurateCell() => new XElement("div", new XAttribute("class", "cell log-aggregation"), string.Empty);
        private static XElement ConfigurateContainer() => new XElement("div", new XAttribute("class", "grid-x grid-margin-x"));

        public Control Slider { get; set; }
        public List<LogItemControl> Items { get; set; }

        public override bool HasError => Items.Any(i => i.HasError);

        public override XElement Build()
        {
            bool hasSimpleLogItems = false;

            var container = ConfigurateContainer();
            var cell = ConfigurateCell();

            container.Add(cell);

            var accordion = new Accordion();

            Items.ForEach(x =>
            {
                if (x is LogAggregationControl)
                    accordion.Items.Add(new AccordionItem(new ParagraphControl { Text = x.Message }, x, HasError));
                else
                {
                    accordion.Items.Add(x);
                    hasSimpleLogItems = true;
                }
            });

            if (hasSimpleLogItems)
                cell.Add(Slider.Build());

            cell.Add(accordion.Build());
            return container;
        }
    }
}
