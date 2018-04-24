namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.LogItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tab
    {
        public Tab Parent { get; set; }

        public string Namespace { get; set; }

        public List<Tab> Tabs { get; set; }

        public List<LogTestAggregation> Items { get; set; }
    }
}
