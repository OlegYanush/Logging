namespace QAutomation.Logging.HtmlReport.Info
{
    using QAutomation.Logging.HtmlReport.Controls;
    using System;

    public abstract class LogItemInfo
    {
        public LogLevel Level { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public bool IsAttachment { get; private set; }

        public LogItemInfo(LogLevel level, DateTime timeStamp, bool isAttachment = false)
        {
            Level = level;
            TimeStamp = timeStamp;
        }

        public abstract bool HasError { get; }

        public abstract int GetCountOfLogsByLevel(LogLevel level);
        public abstract LogItemControl ToControl();
    }
}
