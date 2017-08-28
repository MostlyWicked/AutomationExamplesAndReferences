using difido_client;
using NUnit.Framework;

namespace DifidoReportsReference
{
    [TestFixture]
    public class Examples
    {
        protected IReportDispatcher Report = ReportManager.Instance;

        [Test]
        public void SimpleReport()
        {
            Report.Report("This is a simple report example");
        }

        public void ReportWithInnerText()
        {
            Report.Report("This is the outer text - click to expand", "This is the inner text");
        }

        [Test]
        public void SingleLevelReport(string text = "This is the title of the level - click to expand")
        {
            try
            {
                Report.StartLevel(text);

                Report.Report("This text is nested inside the level");
            }
            finally
            {
                // We must end the level to avoid cases where subsequent reports accidentally write
                // inside this level.
                Report.EndLevel();
            }
        }

        [Test]
        public void MultiLevelReport(string text = "This is the title of the outer level - click to expand")
        {
            try
            {
                Report.StartLevel(text);

                MultiLevelReport("This text is nested inside the level and also contains its own inner text - click to expand");
            }
            finally
            {
                Report.EndLevel();
            }
        }

        [Test]
        public void TestStatusExamples()
        {
            //Reporting with error or failure status at least once will make difido consider the test failed
            Report.Report("This is the failure status, colored red", string.Empty, ReporterTestInfo.TestStatus.failure);
            Report.Report("This is the warning status, colored yellow", string.Empty, ReporterTestInfo.TestStatus.warning);
            Report.Report("This is the failure status, colored red", string.Empty, ReporterTestInfo.TestStatus.failure);
            Report.Report("This is the error status, colored orange", string.Empty, ReporterTestInfo.TestStatus.error);

            try
            {
                Report.StartLevel("A warning/failure/error status inside a level will paint the levels above it - this should be red");
                Report.Report("This is the failure status, colored red", string.Empty, ReporterTestInfo.TestStatus.failure);
                Report.Report("This text is not affected by the failure");
            }
            finally
            {
                Report.EndLevel();
            }
        }

    }
}
