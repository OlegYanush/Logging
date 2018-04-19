namespace QAutomation.Logging.HtmlReport.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogAggregationInfo1 : LogItemInfo
    {
        private LogAggregation _aggregation;

        private readonly List<LogItemInfo> _child = new List<LogItemInfo>();

        public string Message { get; set; }

        public LogAggregationInfo1(LogAggregation aggregation)
        {
            _aggregation = aggregation;

            Message = _aggregation.Message;
            Level = _aggregation.Level;
            TimeStamp = _aggregation.DateTimeStamp;

            WithAttachment = false;
            AttachmentType = AttachmentTypes.None;

            _aggregation.LogItems.ForEach(i => _child.Add(i.ToInfo()));
            HasError = _child.Any(i => i.HasError);
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => _child.Sum(i => i.GetCountOfLogsByLevel(level));

        public override LogItemControl ToControl()
        {
            throw new NotImplementedException();
        }
    }

    public static class LogItemExtension
    {
        public static LogItemInfo ToInfo(this LogItem item)
        {
            switch (item)
            {
                case LogAggregation aggregation:
                    return new LogAggregationInfo1(aggregation);
                case LogMessage message:
                    return new LogMessageInfo1(message);
                case LogAttacment attacment:
                    return new LogAttachmentInfo1(attacment);

                default:
                    throw new Exception($"Unknown type log item type '{item.GetType().Name}'.");
            }
        }
    }
}
