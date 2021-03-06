﻿namespace QAutomation.Logging.HtmlReport
{
    using System.Xml.Linq;

    public class Paragraph : Control
    {
        public Paragraph(string text) { Text = text; }

        public string Text { get; set; }

        public override XElement Build() => new XElement("p", Text);
    }
}
