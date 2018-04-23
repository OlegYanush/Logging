namespace QAutomation.Logging.HtmlReport.Controls
{
    using QAutomation.Logging.HtmlReport.Info;
    using System;
    using System.Xml.Linq;

    public class LogTestAggregationControl : LogAggregationControl
    {
        public string Status { get; set; }

        public string TestName { get; set; }
        public string ErrorMessage { get; set; }

        public TimeSpan Duration { get; set; }
        public string Description { get; set; }

        public LogTestAggregationControl() { }
        public LogTestAggregationControl(LogTestAggregationInfo aggregation)
            : base(aggregation)
        {
            Status = aggregation.Status.ToString();

            TestName = aggregation.TestName;
            ErrorMessage = aggregation.ErrorMessage;

            Duration = aggregation.Duration;
            Description = aggregation.Description;
        }

        public override XElement Build()
        {
            var grid = new Div("grid-x grid-margin-x");
            var cell = new Div("cell log-aggregation");

            var title = new XElement("h3", $"{TestName}{(!string.IsNullOrEmpty(Description) ? $"({Description})" : null)}");
            var status = new XElement("p", $"Status : {Status}");
            var duration = new XElement("p", $"Duration : {Duration}");

            cell.Append(title, status, duration);
            grid.Append(cell);

            if (HasSimpleLogItems)
                cell.Append(new Slider());

            cell.Append(GetAccordion());

            return grid.Build();
        }

        protected override AccordionControl GetAccordion()
        {
            var accordion = base.GetAccordion();

            if (ErrorMessage != null)
                accordion.Items.Insert(accordion.Items.Count - 2, new LogMessageControl(LogLevel.ERROR.ToString(), null, Message, ErrorMessage));

            return accordion;
        }
    }
}
