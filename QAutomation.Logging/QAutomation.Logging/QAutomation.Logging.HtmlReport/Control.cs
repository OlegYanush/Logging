namespace QAutomation.Logging.HtmlReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public abstract class Control
    {
        public abstract XElement Build();
    }
}
