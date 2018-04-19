namespace QAutomation.Logging.HtmlReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class Slider : Control
    {
        private static XElement ConfigurateCell() => new XElement("div", new XAttribute("class", "large-3 cell"), " ");
        private static XElement ConfigurateContainer() => new XElement("div", new XAttribute("class", "grid-x grid-margin-x"));

        private static XElement ConfigurateSliderHandle() => new XElement("span", new XAttribute("class", "slider-handle"),
                                                                                  new XAttribute("data-slider-handle", string.Empty),
                                                                                  new XAttribute("role", "slider"), " ");

        private static XElement ConfigurateSlider()
        {
            var slider = new XElement("div", new XAttribute("class", "slider"),
                                             new XAttribute("data-slider", string.Empty),
                                             new XAttribute("data-initial-start", "0"),
                                             new XAttribute("data-end", "4"));

            slider.Add(ConfigurateSliderHandle());
            slider.Add(ConfigurateSliderFill());
            slider.Add(ConfigurateInput());

            return slider;
        }

        private static XElement ConfigurateSliderFill() => new XElement("span", new XAttribute("class", "slider-fill"),
                                                                                new XAttribute("data-slider-fill", string.Empty), " ");

        private static XElement ConfigurateInput() => new XElement("input", new XAttribute("type", "hidden"), " ");

        public override XElement Build()
        {
            var cell = ConfigurateCell();
            cell.Add(ConfigurateSlider());

            var slider = ConfigurateContainer();
            slider.Add(cell);

            return slider;
        }
    }
}
