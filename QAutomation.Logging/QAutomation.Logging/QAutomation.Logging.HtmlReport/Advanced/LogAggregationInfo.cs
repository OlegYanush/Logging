namespace QAutomation.Logging.HtmlReport.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogAggregationInfo : LogItemInfo
    {
        private LogAggregation _aggregation;

        private readonly List<LogItemInfo> _children = new List<LogItemInfo>();

        public string Message { get; set; }

        public LogAggregationInfo(LogAggregation aggregation)
        {
            _aggregation = aggregation;

            Message = _aggregation.Message;
            Level = _aggregation.Level;
            TimeStamp = _aggregation.DateTimeStamp;

            WithAttachment = false;
            AttachmentType = AttachmentTypes.None;

            _aggregation.LogItems.ForEach(i => _children.Add(i.ToInfo()));

            HasError = _children.Any(i => i.HasError);
            HasSimpleLogItems = _children.Any(i => !(i is LogAggregationInfo));
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => _children.Sum(i => i.GetCountOfLogsByLevel(level));

        public override LogItemControl ToControl() 
            => new LogAggregationControl(Level.ToString(), TimeStamp, Message, HasError, HasSimpleLogItems, _children.Select(i => i.ToControl()));
    }

    public static class LogItemExtension
    {
        public static LogItemInfo ToInfo(this LogItem item)
        {
            switch (item)
            {
                case LogAggregation aggregation:
                    return new LogAggregationInfo(aggregation);
                case LogMessage message:
                    return new LogMessageInfo(message);
                case LogAttachment attacment:
                    return new LogAttachmentInfo(attacment);

                default:
                    throw new Exception($"Unknown type log item type '{item.GetType().Name}'.");
            }
        }
    }
}
