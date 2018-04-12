namespace QAutomation.Logging.HtmlReport.Advanced
{
    using System;

    public abstract class LogItemInfo<T> : ILogItemInfo where T : LogItem
    {
        protected T _logItem;

        protected LogItemInfo(T item) { _logItem = item; }

        public LogLevel Level => _logItem.Level;
        public DateTime TimeStamp => _logItem.DateTimeStamp;

        public abstract bool IsAttachment { get; }
        public abstract bool IsFinite { get; }

        public abstract string Message { get; }
        public abstract string Error { get; }

        public virtual int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public abstract string GetAttachmentPath();
        public abstract AttachmentTypes GetAttachmentType();
    }
}
