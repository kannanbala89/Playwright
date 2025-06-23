using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace PlaywrightMSTestFramework.Reporting
{
    public static class ReportManager
    {
        private static readonly ExtentReports _extent;

        static ReportManager()
        {
            var reportDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "ExtentReports");
            Directory.CreateDirectory(reportDir);
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(reportDir, "PlaywrightReport.html"));
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        public static ExtentReports Instance => _extent;
    }
}
