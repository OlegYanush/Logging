namespace QAutomation.Logging.HtmlReport.Controls
{
    using QAutomation.Logging.HtmlReport.Info;
    using System;
    using System.Xml.Linq;

    public class LogMessageControl : LogItemControl
    {
        private string Message { get; set; }
        private string Error { get; set; }

        public LogMessageControl() { }
        public LogMessageControl(LogMessageInfo logMessage)
            : base(logMessage.Level.ToString(), logMessage.TimeStamp)
        {
            Message = logMessage.Message;
            Error = logMessage.Error?.ToString();
        }
        public LogMessageControl(string level, DateTime? timeStamp, string message, string error = null)
            : base(level, timeStamp)
        {
            Message = message;
            Error = error;
        }

        public override XElement Build()
        {
            var item = base.Build();
            var paragraph = new XElement("p", $"{(TimeStamp.HasValue ? $"{TimeStamp} |" : string.Empty)} {Message}");

            if (Error != null)
                paragraph.Add(new XElement("pre", Error));

            item.Add(paragraph);

            return item;
        }
    }
}
