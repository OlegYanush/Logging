namespace QAutomation.Logging.LogItems
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class LogAggregation : LogItem
    { 
        public string Message { get; set; }
        public List<LogItem> LogItems { get; set; } = new List<LogItem>();
    }
}
