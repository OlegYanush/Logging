namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class LogAggregationControl : LogItemControl
    {
        private static XElement ConfigurateCell() => new XElement("div", new XAttribute("class", "cell log-aggregation"), string.Empty);
        private static XElement ConfigurateContainer() => new XElement("div", new XAttribute("class", "grid-x grid-margin-x"));

        protected List<LogItemControl> _children { get; set; }

        protected readonly string _message;
        protected readonly bool _hasError;
        protected readonly bool _hasSimpleLogItems;

        public LogAggregationControl(string level, DateTime timeStamp, string message, bool hasError, bool hasSimpleLogItems, IEnumerable<LogItemControl> children)
            : base(level, timeStamp)
        {
            _message = message;
            _hasError = hasError;

            _hasSimpleLogItems = hasSimpleLogItems;
            _children = new List<LogItemControl>(children);
        }

        public override XElement Build()
        {
            var container = ConfigurateContainer();
            var cell = ConfigurateCell();

            container.Add(cell);
            var accordion = new Accordion();

            _children.ForEach(x =>
            {
                if (x is LogAggregationControl lac)
                    accordion.Items.Add(new AccordionItem(new ParagraphControl { Text = lac._message }, lac, lac._hasError));
                else
                    accordion.Items.Add(x);
            });

            if (_hasSimpleLogItems)
                cell.Add(new Slider().Build());

            cell.Add(accordion.Build());
            return container;
        }
    }
}
