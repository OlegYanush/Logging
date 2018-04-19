namespace QAutomation.Logging.HtmlReport.Advanced
{
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogMessageInfo1 : LogItemInfo
    {
        private LogMessage _message;

        public string Message { get; set; }
        public string Error { get; set; }

        public LogMessageInfo1(LogMessage message)
        {
            _message = message;

            Message = _message.Message;
            Error = message.Error.ToString();

            TimeStamp = _message.DateTimeStamp;
            Level = _message.Level;

            WithAttachment = false;
            IsFinite = true;

            HasError = Error != null;
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl() => new LogItemControl
        {
            Error = Error,
            Message = Message,
            TimeStamp = TimeStamp,
            Level = Level.ToString()
        };
    }
}
