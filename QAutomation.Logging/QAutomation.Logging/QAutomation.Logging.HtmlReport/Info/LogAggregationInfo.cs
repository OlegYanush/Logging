namespace QAutomation.Logging.HtmlReport.Info
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using LogItems;

    public class LogAggregationInfo : LogItemInfo
    {
        private LogAggregation _aggregation;

        public string Message => _aggregation.Message;
        public readonly List<LogItemInfo> Children  = new List<LogItemInfo>();

        public override bool HasError => Children.Any(i => i.HasError);
        public bool HasSimpleLogItems => Children.Any(i => !(i is LogAggregationInfo));

        public LogAggregationInfo(LogAggregation aggregation)
            : base(aggregation.Level, aggregation.TimeStamp, false)
        {
            _aggregation = aggregation;
            _aggregation.Items.ForEach(i => Children.Add(i.ToInfo()));
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Children.Sum(i => i.GetCountOfLogsByLevel(level));

        public override LogItemControl ToControl() => new LogAggregationControl(this);
    }

    public static class LogItemExtension
    {
        public static LogItemInfo ToInfo(this LogItem item)
        {
            switch (item)
            {
                case LogTestAggregation testAggregation:
                    return new LogTestAggregationInfo(testAggregation);
                case LogAggregation aggregation:
                    return new LogAggregationInfo(aggregation);
                case LogMessage message:
                    return new LogMessageInfo(message);
                case LogAttachment attacment:
                    return new LogAttachmentInfo(attacment);

                default:
                    throw new Exception($"Unknown log item type '{item.GetType().Name}'.");
            }
        }
    }
}
