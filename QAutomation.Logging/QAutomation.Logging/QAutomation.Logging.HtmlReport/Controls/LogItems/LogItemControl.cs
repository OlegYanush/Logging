namespace QAutomation.Logging.HtmlReport.Controls
{
    using System;
    using System.Xml.Linq;

    public abstract class LogItemControl : Control
    {
        public string Level { get; set; }
        protected DateTime? TimeStamp { get; set; }

        protected LogItemControl() { }

        protected LogItemControl(string level, DateTime? timeStamp)
        {
            Level = level;
            TimeStamp = timeStamp;
        }

        public override XElement Build() => new Div($"log-item level-{(Level == "ERROR" ? $"{Level}" : Level)}").Build();
    }
}
