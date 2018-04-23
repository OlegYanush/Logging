namespace QAutomation.Logging.HtmlReport.Info
{
    using QAutomation.Logging.HtmlReport.Controls;
    using QAutomation.Logging.LogItems;

    public class LogAttachmentInfo : LogItemInfo
    {
        private LogAttachment _attachment;

        public string Message => _attachment.Message;
        public AttachmentTypes Type => _attachment.Type;

        private string _pathToAttachment;
        public string PathToAttachment
        {
            get => _pathToAttachment;
            set => _pathToAttachment = _attachment.FilePath.Substring(_attachment.FilePath.IndexOf(_attachment.GetFolder()));
        }

        public override bool HasError => Level == LogLevel.ERROR;
       
        public LogAttachmentInfo(LogAttachment attachment)
            : base(attachment.Level, attachment.TimeStamp, true)
        {
            _attachment = attachment;
            PathToAttachment = _attachment.FilePath;
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl() => new LogImageControl(this);
    }
}
