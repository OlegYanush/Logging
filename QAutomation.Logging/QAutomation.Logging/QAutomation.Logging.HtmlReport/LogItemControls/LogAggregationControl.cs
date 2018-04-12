namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class LogAggregationControl : LogItemControl
    {
        public List<LogItemControl> Items { get; set; }

        public override XElement Build()
        {
            var callout = base.Build();
            var accordion = new Accordion();

            Items.ForEach(x =>
            {
                if (x is LogAggregationControl)
                    accordion.Items.Add(new AccordionItem(new ParagraphControl { Text = x.Message }, x));
                else
                    accordion.Items.Add(x);
            });

            callout.Add(accordion.Build());

            return accordion.Build();
        }
    }
}
