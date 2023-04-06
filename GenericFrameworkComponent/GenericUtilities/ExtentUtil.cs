using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Model.Context;
using AventStack.ExtentReports.Reporter;
using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.UIFrameworkUtilities;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace GenericFrameworkComponent.Utilities
{
    public class ExtentUtil
    {
        public static ExtentHtmlReporter? htmlReporter;

        public static ExtentReports? extent;

        public static ExtentTest? extTestFeature;

        public static ExtentTest? extTestScenario;

        public static ExtentTest? extTestStep;

        private ExtentUtil()
        {

        }

        public static void extentInit()
        {
            htmlReporter = new ExtentHtmlReporter(FileFolderUtil.extentReportFolderCompletePath());
            htmlReporter.LoadConfig(FileFolderUtil.extentReportConfigFileCompletePath());

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AnalysisStrategy = AnalysisStrategy.BDD;
            extent.AddSystemInfo("Operating System", Environment.OSVersion.Version.ToString().Split('.')[0]);
            extent.AddSystemInfo("Operating System Version", Environment.OSVersion.Platform.ToString().Substring(0, 3));
            extent.AddSystemInfo("User Name", WindowsIdentity.GetCurrent().Name);
            extent.AddSystemInfo("Environment", ExcelUtil.cs.environmentName);
        }

        public static void LogInfo(string message)
        {
            extTestStep.Log(Status.Info, HTMLReportUtil.infoStringBlueColor(message, Status.Info.ToString()));
        }

        public static void LogWarn(string message)
        {
            extTestStep.Log(Status.Warning, HTMLReportUtil.warningStringOrangeColor(message, Status.Warning.ToString()));
        }

        public static void LogDebug(string message)
        {
            extTestStep.Log(Status.Debug, HTMLReportUtil.infoStringBlueColor(message, Status.Debug.ToString()));
        }

        public static void LogError(string message)
        {
            extTestStep.Error(MarkupHelper.CreateLabel("Failed at point - ", ExtentColor.Red));
            extTestStep.Log(Status.Error, HTMLReportUtil.failStringRedColor(message, Status.Error.ToString()));
        }

        public static void LogFail(string message)
        {
            extTestStep.Fail(MarkupHelper.CreateLabel("Failed at point - ", ExtentColor.Red));
            extTestStep.Log(Status.Fail, HTMLReportUtil.failStringRedColor(message, Status.Fail.ToString()));
        }

        public static void LogFatal(string message)
        {
            extTestStep.Fatal(MarkupHelper.CreateLabel("Failed at point - ", ExtentColor.Red));
            extTestStep.Log(Status.Fatal, HTMLReportUtil.failStringRedColor(message, Status.Fatal.ToString()));
        }

        public static void LogPass(string message)
        {
            extTestStep.Log(Status.Pass, HTMLReportUtil.passStringGreenColor(message));
        }

        public static void LogSkip(string message)
        {
            extTestStep.Log(Status.Skip, HTMLReportUtil.infoStringBlueColor(message, Status.Skip.ToString()));
        }

        public static void attachFailureScreenshot()
        {
            byte[] imageArray = File.ReadAllBytes(@WebDriverUtils.ScreenShotCapture("Taking Screenshot"));
            extTestStep.Fail(HTMLReportUtil.showBase64Image("data:image/png;base64," + Convert.ToBase64String(imageArray)));
        }

        public static void extentClose()
        {
            extent.Flush();
            BufferUtilSuiteLevel.extentReportPath = FileFolderUtil.extentReportUpdatedFileName();
            FileFolderUtil.moveFileFromOneToAnotherFolder(FileFolderUtil.extentReportDefaultFileName(), BufferUtilSuiteLevel.extentReportPath);
        }

        public static void openReport(string ReportPath)
        {
            Process.Start(@ReportPath);
        }
    }
}
