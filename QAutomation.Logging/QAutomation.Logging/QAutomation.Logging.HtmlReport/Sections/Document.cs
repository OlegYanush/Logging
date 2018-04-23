namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.HtmlReport.Info;
    using System.Linq;
    using System.Xml.Linq;

    public class Document : Control
    {
        private Control _html;
        private string _path;

        public Document(LogTestAggregationInfo info)
        {
            _html = info.ToControl();
            _path = info.TestName;
        }
        public Document(Html html, string path)
        {
            _html = html;
            _path = path;
        }

        public override XElement Build()
        {
            var document = new XDocument();
            var title = _path.Split('.').Last();

            var head = new Head(new Title(title));

            head.Add(new Css("src/css/foundation.min.css"));
            head.Add(new Css("src/css/app.css"));

            var body = new Body(_html);

            body.Add(new Script("src/js/jquery.js"));
            body.Add(new Script("src/js/foundation.min.js"));
            body.Add(new Script("src/js/app.js"));

            var html = new Html(head, body);

            document.Add(html.Build());
            document.Save($"{_path}.html");

            return document.Root;
        }
    }
}
