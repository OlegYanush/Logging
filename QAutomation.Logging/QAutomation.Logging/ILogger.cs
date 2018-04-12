namespace QAutomation.Logging
{
    using System;

    public interface ILogger
    {
        ILogger LOGITEM(LogItem logItem);

        ILogger TRACE(string message, Exception exception = null);

        ILogger DEBUG(string message, Exception exception = null);

        ILogger WARN(string message, Exception exception = null);

        ILogger INFO(string message, Exception exception = null);

        ILogger ERROR(string message, Exception exception = null);

        ILogger INNER(string message, bool permitCreateInnerLoggers = false);

        ILogger INNER(string className, string methodName, bool permitCreateInnerLoggers = false);
    }
}
