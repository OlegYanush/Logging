namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class LogItemControl : Control
    {
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }

        public string Message { get; set; }

        public override XElement Build()
        {
            var message = new XElement("div", new XAttribute("class", $"callout small level-{(Level == "ERROR" ? $"{Level} alert" : Level)}"),
                                              new XElement("p", $"{TimeStamp} | {Message}"));

            return message;
        }
    }
}
