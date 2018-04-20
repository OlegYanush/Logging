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
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            var formatter = new BinaryFormatter();
            HiLogger logger = null;

            using (var stream = new FileStream(@"C:\Users\Aleh_Yanushkevich\Desktop\1\Tests.DevDest.ForgetMe.ForgetMeTests(IE).Pr00011.log.bin", FileMode.Open))
            {
                logger = (HiLogger)formatter.Deserialize(stream);
            }

            //var count = info.GetCountOfLogsByLevel(LogLevel.TRACE);

            //logger = new HiLogger("Tests.TagsExporting.InabilityToExportDefaultTags.SAP1DX_3687");

            //var inner = logger.INNER("Create page");
            //inner.DEBUG("Start to cteate page.");
            //inner.DEBUG("Page successfully created");

            //var subinner = inner.INNER("create sub page");
            //subinner.INFO("create very sub inner page");

            //subinner.ERROR("test failed", new NotSupportedException("Not supperoted"));
            var info = new LogAggregationInfo(logger.Aggregation);

            //var control = logger.Aggregation.ToControl();

            //var xml = control.Build();

            //var xml = info.ToControl().Build();

            var document = new XDocument();

            var head = new Head() { Title = logger.Name.Split('.').Last() };
            var body = new Body();

            body.Add(info.ToControl());

            body.Add(new Script("src/js/jquery.js"));
            body.Add(new Script("src/js/foundation.min.js"));
            body.Add(new Script("src/js/app.js"));

            var html = new Html(head, body);
            document.Add(html.Build());

            document.Save("index.html");
        }
    }
}
