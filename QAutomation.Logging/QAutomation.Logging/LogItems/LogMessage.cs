namespace QAutomation.Logging.LogItems
{
    using System;

    [Serializable]
    public class LogMessage : LogItem
    {
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}
