namespace QAutomation.Logging.HtmlReport.LogItemControls
{
    using System.Linq;
    using System.Xml.Linq;

    public class LogErrorControl : LogItemControl
    {
        public string Error { get; set; }

        public override XElement Build()
        {
            var control = base.Build();

            if (Error != null)
            {
                var p = control.Nodes().OfType<XElement>().First(x => x.Name == "p");
                p.Add(new XElement("pre", Error));
            }

            return control;
        }
    }
}
