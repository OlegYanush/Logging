namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.HtmlReport.LogItemControls;
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

        LogItemControl ToControl();
    }
}
