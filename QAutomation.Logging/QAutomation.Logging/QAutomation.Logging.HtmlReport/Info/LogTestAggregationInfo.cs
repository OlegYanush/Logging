namespace QAutomation.Logging.HtmlReport.Info
{
    using System;
    using QAutomation.Logging.HtmlReport.Controls;
    using QAutomation.Logging.LogItems;

    public class LogTestAggregationInfo : LogAggregationInfo
    {
        private LogTestAggregation _testAggregation;

        public TestStatus Status => _testAggregation.TestStatus;

        public TimeSpan Duration => _testAggregation.Duration;
        public string Description => _testAggregation.Description;
        
        public string TestName => _testAggregation.TestName;
        public string ErrorMessage => _testAggregation.ErrorMessage;

        public LogTestAggregationInfo(LogTestAggregation aggregation)
            : base(aggregation)
        {
            _testAggregation = aggregation;
        }

        public override LogItemControl ToControl() => new LogTestAggregationControl(this);
    }
}
