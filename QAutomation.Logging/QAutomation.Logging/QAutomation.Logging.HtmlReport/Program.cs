namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.HtmlReport.Info;
    using QAutomation.Logging.HtmlReport.Controls;
    using QAutomation.Logging.LogItems;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            var formatter = new BinaryFormatter();
            LogAggregation aggreagation = null;

            using (var stream = new FileStream(@"C:\Users\Aleh_Yanushkevich\Desktop\Tests.DevDest.ForgetMe.ForgetMeTests(Chrome).Pr00011.log (1)\Tests.DevDest.ForgetMe.ForgetMeTests(Chrome).Pr00011.log.bin", FileMode.Open))
            {
                aggreagation = (LogAggregation)formatter.Deserialize(stream);
            }

            //var count = info.GetCountOfLogsByLevel(LogLevel.TRACE);

            //logger = new HiLogger("Tests.TagsExporting.InabilityToExportDefaultTags.SAP1DX_3687");

            //var inner = logger.INNER("Create page");
            //inner.DEBUG("Start to cteate page.");
            //inner.DEBUG("Page successfully created");

            //var subinner = inner.INNER("create sub page");
            //subinner.INFO("create very sub inner page");

            //subinner.ERROR("test failed", new NotSupportedException("Not supperoted"));
            var info = new LogTestAggregationInfo(aggreagation as LogTestAggregation);

            //var control = logger.Aggregation.ToControl();

            //var xml = control.Build();

            //var xml = info.ToControl().Build();

            new Document(info).Build();
        }
    }
}
