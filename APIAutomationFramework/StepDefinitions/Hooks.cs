using AventStack.ExtentReports.Gherkin.Model;
using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.UIFrameworkUtilities;
using GenericFrameworkComponent.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace APIAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scContext)
        {
            BufferUtilSuiteLevel.scenarioName = scContext.ScenarioInfo.Title;
            LogUtil.infoLog("-----------------------Starting scenario execution: " + BufferUtilSuiteLevel.scenarioName + "---------------------------");
            ExtentUtil.extTestScenario = ExtentUtil.extTestFeature.CreateNode<Scenario>(BufferUtilSuiteLevel.scenarioName);
            DBUtil.initDBConnection(ExcelUtil.cs.dbDataSource, ExcelUtil.cs.dbName, ExcelUtil.cs.dbUsername, ExcelUtil.cs.dbPassword);
            DBUtil.openDBConnection();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            LogUtil.infoLog("-----------------------Stopping scenario execution: " + BufferUtilSuiteLevel.scenarioName + "---------------------------");
            DBUtil.closeDBConnection();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (stepType == "Given")
                ExtentUtil.extTestStep = ExtentUtil.extTestScenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            else if (stepType == "When")
                ExtentUtil.extTestStep = ExtentUtil.extTestScenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
            else if (stepType == "Then")
                ExtentUtil.extTestStep = ExtentUtil.extTestScenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            else if (stepType == "And")
                ExtentUtil.extTestStep = ExtentUtil.extTestScenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);

            LogUtil.infoLog("------------------------Starting step execution: " + ScenarioStepContext.Current.StepInfo.Text + "-----------------------");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scContext)
        {
            if (scContext.TestError != null)
            {
                if (BufferUtilSuiteLevel.exception != null)
                {
                    
                }
                else
                {
                    
                }
            }
            else
            {

            }

            LogUtil.infoLog("------------------------Stopping step execution: " + ScenarioStepContext.Current.StepInfo.Text + "-----------------------");
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LogUtil.logInit();
            LogUtil.infoLog("-------------------------------------------------------Test Run Started--------------------------------------------------");
            FileFolderUtil.createFolderIfNotExist(FileFolderUtil.reportFolderCompletePath());
            FileFolderUtil.createFolderIfNotExist(FileFolderUtil.extentReportFolderCompletePath());
            FileFolderUtil.createFolderIfNotExist(FileFolderUtil.logFolderCompletePath());
            ExcelUtil.dataFromAutomationExcelSheetCell();
            ExtentUtil.extentInit();
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentUtil.extentClose();
            ExtentUtil.openReport(BufferUtilSuiteLevel.extentReportPath);
            LogUtil.infoLog("-------------------------------------------------------Test Run Ended------------------------------------------------------");
            FileFolderUtil.moveFileFromOneToAnotherFolder(FileFolderUtil.logDefaultFileName(), FileFolderUtil.logUpdatedFileName());
            FileFolderUtil.deleteFile(FileFolderUtil.logDefaultFileName());
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            LogUtil.infoLog("--------------------------------Starting feature execution: " + featurecontext.FeatureInfo.Title + "-----------------------");
            ExtentUtil.extTestFeature = ExtentUtil.extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
        }


        [AfterFeature]
        public static void AfterFeature(FeatureContext featurecontext)
        {
            LogUtil.infoLog("--------------------------------Stopping feature execution: " + featurecontext.FeatureInfo.Title + "-----------------------");
        }
    }
}