namespace QAutomation.Logging.HtmlReport.Info
{
    using QAutomation.Logging.HtmlReport.Controls;
    using QAutomation.Logging.LogItems;

    public class LogMessageInfo : LogItemInfo
    {
        private LogMessage _message;

        public string Message => _message.Message;
        public string Error => _message.Error?.ToString();

        public override bool HasError => Error != null;

        public LogMessageInfo(LogMessage message)
            : base(message.Level, message.TimeStamp, false)
        {
            _message = message;
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl() => new LogMessageControl(this);
    }
}
