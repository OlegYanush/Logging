namespace QAutomation.Logging.HtmlReport.Advanced
{
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using System;

    public abstract class LogItemInfo
    {
        public bool WithAttachment { get; protected set; }

        public DateTime TimeStamp { get; protected set; }
        public LogLevel Level { get; protected set; }

        public bool HasError { get; protected set; }
        public bool HasSimpleLogItems { get; protected set; }

        public string PathToAttachment { get; protected set; }
        public AttachmentTypes AttachmentType { get; protected set; }

        public abstract int GetCountOfLogsByLevel(LogLevel level);
        public abstract LogItemControl ToControl();
    }
}
