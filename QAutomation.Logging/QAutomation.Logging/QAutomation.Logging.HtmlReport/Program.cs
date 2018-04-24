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
            LogTestAggregation aggreagation = null;

            using (var stream = new FileStream(@"C:\Users\Aleh_Yanushkevich\Desktop\Tests.DevDest.ForgetMe.ForgetMeTests(Chrome).Pr00011.log (1)\Logs\Tests.DevDest.ForgetMe.ForgetMeTests(Chrome).Pr00011.log.bin", FileMode.Open))
            {
                aggreagation = (LogTestAggregation)formatter.Deserialize(stream);
            }

            var root = @"C:\Users\Aleh_Yanushkevich\Desktop\test";

            var generator = new HtmlReportGenerator(root);

            generator.GenerateReport(Directory.GetCurrentDirectory());
            //generator.MagicFunction(root, "Logs", aggreagation.Items.OfType<LogAttachment>().ToList());

            //var info = new LogTestAggregationInfo(aggreagation);
            //new Document(info).Build();
        }
    }
}
