namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Xml.Linq;

    public class LogItemControl : Control
    {
        private static XElement ConfigurateLogItemControl(string level) => new XElement("div", new XAttribute("class", $"log-item level-{(level == "ERROR" ? $"{level}" : level)}"));
        private static XElement ConfigurateParagraph(string message, DateTime timeStamp, string error = null)
        {
            var paragraph = new XElement("p", $"{timeStamp} | {message}");

            if (error != null)
                paragraph.Add(new XElement("pre", error));

            return paragraph;
        }

        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }

        public string Message { get; set; }
        public string Error { get; set; }

        public virtual bool HasError => Error != null;

        public override XElement Build()
        {
            var logItem = ConfigurateLogItemControl(Level);
            logItem.Add(ConfigurateParagraph(Message, TimeStamp, Error));

            return logItem;
        }
    }
}
