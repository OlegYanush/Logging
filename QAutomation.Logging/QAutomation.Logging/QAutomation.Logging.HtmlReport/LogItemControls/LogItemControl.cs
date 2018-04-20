namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System;
    using System.Xml.Linq;

    public abstract class LogItemControl : Control
    {
        protected static XElement ConfigurateLogItemControl(string level) => new XElement("div", new XAttribute("class", $"log-item level-{(level == "ERROR" ? $"{level}" : level)}"));

        protected LogItemControl(string level, DateTime timeStamp)
        {
            _level = level;
            _timeStamp = timeStamp;
        }

        protected string _level;
        protected DateTime _timeStamp;

        public override XElement Build() => ConfigurateLogItemControl(_level);
    }
}
