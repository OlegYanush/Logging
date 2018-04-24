namespace QAutomation.Logging.HtmlReport.Info
{
    using Controls;
    using LogItems;
    using System.IO;

    public class LogAttachmentInfo : LogItemInfo
    {
        public static string RootDirectory;

        private LogAttachment _attachment;

        public string Message => _attachment.Message;
        public AttachmentTypes Type => _attachment.Type;

        private string _pathToAttachment;
        public string PathToAttachment
        {
            get
            {
                if(_pathToAttachment == null)
                {
                    var value = _attachment.FilePath;
                    _pathToAttachment = Path.Combine(RootDirectory, value.Substring(value.IndexOf(_attachment.GetFolder()) + _attachment.GetFolder().Length + 1));
                }

                return _pathToAttachment;
            }
        }

        public override bool HasError => Level == LogLevel.ERROR;

        public LogAttachmentInfo(LogAttachment attachment)
            : base(attachment.Level, attachment.TimeStamp, true)
        {
            _attachment = attachment;
        }

        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl() => new LogImageControl(this);
    }
}
