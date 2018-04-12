namespace QAutomation.Logging.LogItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class LogAttacment : LogItem
    {
        public AttachmentTypes Type { get; set; }
        public string FilePath { get; set; }
    }
}
