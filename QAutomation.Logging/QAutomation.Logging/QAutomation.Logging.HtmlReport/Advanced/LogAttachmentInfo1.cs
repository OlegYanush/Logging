namespace QAutomation.Logging.HtmlReport.Advanced
{
    using System;
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;

    public class LogAttachmentInfo1 : LogItemInfo
    {
        private LogAttacment _attachment;

        public LogAttachmentInfo1(LogAttacment attachment)
        {
            _attachment = attachment;

            AttachmentType = _attachment.Type;
            PathToAttachment = _attachment.FilePath;

            WithAttachment = true;
            IsFinite = true;

            Level = _attachment.Level;
            TimeStamp = _attachment.DateTimeStamp;

            HasError = Level == LogLevel.ERROR;
        }


        public override int GetCountOfLogsByLevel(LogLevel level) => Level == level ? 1 : 0;

        public override LogItemControl ToControl()
        {
            throw new NotImplementedException();
        }
    }
}
