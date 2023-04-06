using GenericFrameworkComponent.UIFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class CommonConstants
    {

        public static readonly string flagYes = "Yes";
        public static readonly string flagNo = "No";
        public static readonly string platformRemote = "Remote";
        public static readonly string platformLocal = "Local";

        public static readonly string platformRemoteBrowserstack = "Browserstack";
        public static readonly string platformRemoteSauceLabs = "SauceLabs";

        public const string browserChrome = "CHROME";
        public const string browserEdge = "EDGE";

        public static readonly string browserRemoteVersion = "latest";
        public static readonly string remoteSeleniumVersion = "4.7.2";

        public static readonly string automationControlExcelDataSheetName = "AppControl";

        public static readonly string reportFolderName = "\\ExecutionReport";
        public static readonly string extentReportFolderName = "\\ExtentReport";
        public static readonly string screenshotFolderName = "\\Screenshots";
        public static readonly string logFolderName = "\\Logs";

        public static readonly string extentReportConfigPath = "\\Resources\\extent-config.xml";
        public static readonly string extentReportDefaultFile = "\\ExtentReport\\index.html";

        public static readonly string testDataExcelPath = "\\Resources\\TestData\\TestData.xlsx";
        public static readonly string automationControlSheetExcelPath = "\\Resources\\ExcelFiles\\AutomationControlSheet.xlsx";
        public static readonly string logFilePath = "\\Debug\\net48\\logFile.txt";
        public static readonly string log4netConfigPath = "\\Resources\\Log4Net.xml";

        public static readonly double DEFAULT_WAIT_TIME = 20;

        public static string extentReportFileName = "ExtentReport_" + WebDriverUtils.dateTimeFolderPatterName() + ".html";
        public static string logFileName = "Log_" + WebDriverUtils.dateTimeFolderPatterName() + ".txt";

        public static readonly string JSONfilePath = "//Resources//JSONFiles//";

        public static readonly string dbStatusClosed = "Closed";
    }
}
