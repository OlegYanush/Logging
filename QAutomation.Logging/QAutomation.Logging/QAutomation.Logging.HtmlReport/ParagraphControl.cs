using System;
namespace QAutomation.Logging.HtmlReport
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class ParagraphControl : Control
    {
        public string Text { get; set; }

        public override XElement Build() => new XElement("p", Text);
    }
}
