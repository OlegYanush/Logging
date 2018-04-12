namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.HtmlReport.Advanced;
    using QAutomation.Logging.HtmlReport.LogItemControls;
    using QAutomation.Logging.LogItems;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var formatter = new BinaryFormatter();
            HiLogger logger = null;

            using (var stream = new FileStream(@"C:\Users\Aleh_Yanushkevich\Desktop\Logs\Logs\Tests.TagsExporting.InabilityToExportDefaultTags.SAP1DX_3687.log.bin", FileMode.Open))
            {
                logger = (HiLogger)formatter.Deserialize(stream);
            }

            var info = new LogAggregationInfo(logger.Aggregation);

            var count = info.GetCountOfLogsByLevel(LogLevel.TRACE);

            logger = new HiLogger("Tests.TagsExporting.InabilityToExportDefaultTags.SAP1DX_3687");

            var inner = logger.INNER("Create page");
            inner.DEBUG("Start to cteate page.");
            inner.DEBUG("Page successfully created");

            var subinner = inner.INNER("create sub page");
            subinner.INFO("create very sub inner page");

            logger.ERROR("test failed", new NotSupportedException("Not supperoted"));

            var control = logger.Aggregation.ToControl();

            var xml = control.Build();
        }
    }

    public static class LogItemExtensions
    {
        public static LogItemControl ToControl(this LogItem item)
        {
            if (item is LogMessage logMessage)
                return new LogErrorControl
                {
                    Error = logMessage.Error?.ToString(),
                    Level = logMessage.Level.ToString(),
                    Message = logMessage.Message,
                    TimeStamp = logMessage.DateTimeStamp
                };
            if (item is LogAggregation logAggregation)
                return new LogAggregationControl
                {
                    Message = logAggregation.Message,
                    Level = logAggregation.Level.ToString(),
                    TimeStamp = logAggregation.DateTimeStamp,
                    Items = logAggregation.LogItems.Select(x => x.ToControl()).ToList()
                };

            throw new Exception("Not found.");
        }
    }
}
