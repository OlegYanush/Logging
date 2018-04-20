namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Xml.Linq;

    public class LogMessageControl : LogItemControl
    {
        protected static XElement ConfigurateParagraph(string message, DateTime timeStamp, string error = null)
        {
            var paragraph = new XElement("p", $"{timeStamp} | {message}");

            if (error != null)
                paragraph.Add(new XElement("pre", error));

            return paragraph;
        }

        private readonly string _message;
        private readonly string _error;

        public LogMessageControl(string level, DateTime timeStamp, string message, string error)
            : base(level,timeStamp)
        {
            _message = message;
            _error = error;
        }

        public override XElement Build()
        {
            var logItem = base.Build();
            logItem.Add(ConfigurateParagraph(_message, _timeStamp, _error));

            return logItem;
        }
    }
}
