namespace QAutomation.Logging.HtmlReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class Head : Control
    {
        private static XElement ConfigurateLinkTag(string pathToCssFile) => new XElement("link", new XAttribute("rel", "stylesheet"),
                                                                                                 new XAttribute("href", pathToCssFile));

        private static XElement ConfigurateTitle(string title) => new XElement("title", title);

        public string Title { get; set; }
        public List<string> PathsToCss { get; set; } = new List<string>() { "src/css/foundation.min.css", "src/css/app.css" };

        public override XElement Build()
        {
            var head = new XElement("head", new XElement("meta", new XAttribute("charset", "utf-8")), ConfigurateTitle(Title));

            foreach (var path in PathsToCss)
                head.Add(ConfigurateLinkTag(path));

            return head;
        }
    }
}
