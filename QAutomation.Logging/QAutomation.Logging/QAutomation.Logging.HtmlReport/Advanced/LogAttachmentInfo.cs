namespace QAutomation.Logging.HtmlReport.Advanced
{
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogAttachmentInfo : LogItemInfo
    {
        private LogAttachment _attachment;

        public string Message { get; protected set; }

        public LogAttachmentInfo(LogAttachment attachment)
        {
            _attachment = attachment;

            AttachmentType = _attachment.Type;
            PathToAttachment = _attachment.FilePath.Substring(_attachment.FilePath.IndexOf("Screenshot"));

            WithAttachment = true;
            Message = _attachment.Message;

            Level = _attachment.Level;
            TimeStamp = _attachment.DateTimeStamp;

            HasError = Level == LogLevel.ERROR;
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl() => new LogImageControl(Level.ToString(), TimeStamp, Message, PathToAttachment);
    }
}
