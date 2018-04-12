namespace QAutomation.Logging.HtmlReport
{
    using System;

    public interface ILogItemInfo
    {
        bool IsAttachment { get; }
        bool IsFinite { get; }

        DateTime TimeStamp { get; }
        LogLevel Level { get; }

        string Message { get; }
        string Error { get; }

        int GetCountOfLogsByLevel(LogLevel level);
    }
}
