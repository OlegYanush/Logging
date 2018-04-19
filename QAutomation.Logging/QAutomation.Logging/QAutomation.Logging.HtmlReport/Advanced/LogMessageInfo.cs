namespace QAutomation.Logging.HtmlReport.Advanced
{
    using System;
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogMessageInfo : LogItemInfo<LogMessage>
    {
        public LogMessageInfo(LogMessage item) : base(item) { }

        public override string Message => _logItem.Message;

        public override bool IsAttachment => false;
        public override bool IsFinite => true;

        public override string GetAttachmentPath() => null;
        public override AttachmentTypes GetAttachmentType() => throw new NotSupportedException();

        public override LogItemControl ToControl() => new LogItemControl()
        {
            Error = Error,
            Level = Level.ToString(),
            Message = Message,
            TimeStamp = TimeStamp
        };

        public override string Error => _logItem.Error?.ToString();
    }
}
