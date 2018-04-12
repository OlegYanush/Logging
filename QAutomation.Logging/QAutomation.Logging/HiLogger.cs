namespace QAutomation.Logging
{
    using LogItems;
    using System;

    [Serializable]
    public class HiLogger : ILogger
    {
        public static event EventHandler<LogItem> OnAnyLogItem;

        private bool _allInnerLoggersAsInfo = false;

        public event EventHandler<LogItem> OnLogItem;

        public string Name { get; protected set; }
        public LogAggregation Aggregation { get; protected set; }
        public static string LoggedFilesFolderPath { get; set; } = "Logs\\Files";

        public HiLogger(string name)
        {
            Name = name;
            Aggregation = new LogAggregation { Level = LogLevel.DEBUG, DateTimeStamp = DateTime.UtcNow, Message = name };
        }

        public HiLogger(LogAggregation aggregation) { Aggregation = aggregation; }

        public string GetLoggedFilesFolder() => LoggedFilesFolderPath;

        public ILogger LOGITEM(LogItem logItem)
        {
            Aggregation.LogItems.Add(logItem);
            Logger_OnLogItem(this, logItem);

            return this;
        }

        public ILogger LOG(LogLevel level, string message, Exception exception = null)
          => LOGITEM(new LogMessage { DateTimeStamp = DateTime.UtcNow, Level = level, Error = exception, Message = message });

        public ILogger TRACE(string message, Exception exception = null) => !_allInnerLoggersAsInfo ? LOG(LogLevel.TRACE, message, exception) : this;

        public ILogger DEBUG(string message, Exception exception = null) => !_allInnerLoggersAsInfo ? LOG(LogLevel.DEBUG, message, exception) : this;

        public ILogger ERROR(string message, Exception exception = null) => LOG(LogLevel.ERROR, message, exception);

        public ILogger INFO(string message, Exception exception = null) => LOG(LogLevel.INFO, message, exception);

        public ILogger WARN(string message, Exception exception = null) => LOG(LogLevel.WARN, message, exception);

        public ILogger INNER(string message, bool permitCreateInnerLoggers = false)
        {
            if (_allInnerLoggersAsInfo)
            {
                LOG(LogLevel.INFO, message);
                return this;
            }

            var aggregation = new LogAggregation
            {
                Message = message,
                Level = LogLevel.DEBUG,
                DateTimeStamp = DateTime.UtcNow,
            };

            LOGITEM(aggregation);
            var logger = new HiLogger(aggregation) { Name = message };

            logger._allInnerLoggersAsInfo = permitCreateInnerLoggers;
            logger.OnLogItem += Logger_OnLogItem;

            return logger;
        }

        public ILogger INNER(string className, string methodName, bool permitCreateInnerLoggers = false)
            => INNER($"{className} > {methodName}", permitCreateInnerLoggers);

        private void Logger_OnLogItem(object sender, LogItem e)
        {
            try
            {
                OnLogItem?.Invoke(this, e);
                OnAnyLogItem?.Invoke(this, e);
            }
            catch { };
        }
    }
}
