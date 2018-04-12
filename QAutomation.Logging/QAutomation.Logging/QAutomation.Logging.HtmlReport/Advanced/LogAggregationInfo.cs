namespace QAutomation.Logging.HtmlReport.Advanced
{
    using QAutomation.Logging.LogItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogAggregationInfo : LogItemInfo<LogAggregation>
    {
        public readonly List<ILogItemInfo> Items = new List<ILogItemInfo>();

        public LogAggregationInfo(LogAggregation item)
            : base(item)
        {
            foreach(var logItem in item.LogItems)
            {
                if (logItem is LogMessage lm)
                    Items.Add(new LogMessageInfo(lm));

                else if (logItem is LogAttacment lf)
                    Items.Add(new LogAttachmentInfo(lf));

                else if (logItem is LogAggregation la)
                    Items.Add(new LogAggregationInfo(la));
            }
        }

        public override bool IsAttachment => false;
        public override bool IsFinite => false;

        public override string Message => _logItem.Message;
        public override string Error => null;

        public override string GetAttachmentPath() => null;

        public override AttachmentTypes GetAttachmentType() => throw new NotSupportedException();

        public override int GetCountOfLogsByLevel(LogLevel level)
        {
            var count = 0;

            foreach(var item in Items)
            {
                count += item.GetCountOfLogsByLevel(level);
            }

            return count;
        }
    }
}
