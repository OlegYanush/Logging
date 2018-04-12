namespace QAutomation.Logging
{
    using System;

    [Serializable]
    public abstract class LogItem
    {
        public LogLevel Level { get; set; }
      
        public DateTime DateTimeStamp { get; set; }
    }
}
