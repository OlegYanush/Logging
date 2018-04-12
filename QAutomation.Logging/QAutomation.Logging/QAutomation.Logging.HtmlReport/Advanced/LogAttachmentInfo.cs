namespace QAutomation.Logging.HtmlReport.Advanced
{
    using QAutomation.Logging.LogItems;

    public class LogAttachmentInfo : LogItemInfo<LogAttacment>
    {
        public LogAttachmentInfo(LogAttacment logFile) : base(logFile) { }

        public override bool IsAttachment => true;
        public override bool IsFinite => true;

        public override string Message => null;
        public override string Error => null;

        public override string GetAttachmentPath() => _logItem.FilePath;
        public override AttachmentTypes GetAttachmentType() => _logItem.Type;
    }
}
