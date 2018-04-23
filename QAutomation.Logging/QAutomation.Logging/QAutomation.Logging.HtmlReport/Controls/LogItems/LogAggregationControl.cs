namespace QAutomation.Logging.HtmlReport.Controls
{
    using QAutomation.Logging.HtmlReport.Info;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class LogAggregationControl : LogItemControl
    {
        public List<LogItemControl> Children { get; set; }

        protected string Message { get; set; }
        protected bool HasError { get; set; }
        protected bool HasSimpleLogItems { get; set; }

        public LogAggregationControl() { Children = new List<LogItemControl>(); }
        public LogAggregationControl(LogAggregationInfo info)
            : base(info.Level.ToString(), info.TimeStamp)
        {
            Message = info.Message;
            HasError = info.HasError;

            HasSimpleLogItems = info.HasSimpleLogItems;
            Children = new List<LogItemControl>(info.Children.Select(i => i.ToControl()));
        }

        protected virtual AccordionControl GetAccordion()
        {
            var accordion = new AccordionControl();

            Control control = null;
            foreach (var child in Children)
            {
                if (child is LogAggregationControl lac)
                    control = new AccordionItemControl(new Paragraph(lac.Message), lac, lac.HasError);
                else
                    control = child;

                accordion.Items.Add(control);
            }

            return accordion;
        }

        public override XElement Build()
        {
            var grid = new Div("grid-x grid-margin-x");
            var cell = new Div("cell log-aggregation");

            grid.Append(cell);

            if (HasSimpleLogItems)
                cell.Append(new Slider());

            cell.Append(GetAccordion());

            return grid.Build();
        }
    }
}
