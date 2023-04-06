using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.Utilities;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UIAutomationFramework.Modules;
using UIAutomationFramework.POJOs;

namespace UIAutomationFramework.StepDefinitions
{
    [Binding]
    public class ThisIsTestFeature2StepDefinitions
    {
        [Given(@"This is a prerequisite step where read ""([^""]*)"" from sheet ""([^""]*)"" in excel")]
        public void GivenThisIsAPrerequisiteStepWhereReadFromSheetInExcel(string testDataName, string sheetName)
        {
            BufferUtilSuiteLevel.keyValuePairsForLoginSheet = ExcelUtil.getTestDataFromSheet(sheetName);
            CommonModule.navigateToURL(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.URL));
        }

        [When(@"This is a condition step for reading for ""([^""]*)"" data")]
        public void WhenThisIsAConditionStepForReadingForData(string testDataName)
        {
            LogUtil.infoLog(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Username));
            LogUtil.infoLog(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Password));
        }

        [Given(@"This is a prerequisite step to test set of data:")]
        public void GivenThisIsAPrerequisiteStepToTestSetOfData(Table table)
        {
            var something = table.CreateSet<TestDataInstances>();
            foreach (TestDataInstances c in something)
            {
                TestDataInstances.TestDataList.Add(c.TestData);
                TestDataInstances.SheetNameList.Add(c.SheetName);
            }

            LogUtil.infoLog("Test data is " + TestDataInstances.TestDataList[1]);
            LogUtil.infoLog("Sheet Name is " + TestDataInstances.SheetNameList[0]);

            BufferUtilSuiteLevel.keyValuePairsForLoginSheet = ExcelUtil.getTestDataFromSheet(TestDataInstances.SheetNameList[0]);
            CommonModule.navigateToURL(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, TestDataInstances.TestDataList[1], ColumnParam.URL));

            LogUtil.infoLog(DBUtil.executeQueryAndGetData(DBUtil.designWhereClause("EMPDATA", "FirstName", "FN", "", true)));
            JSONUtil.readJSONObject(JSONUtil.getJSONData(JSONUtil.LoadJson("Test")), "LoginData", "Username1");
            JSONUtil.readJSONArray(JSONUtil.getJSONData(JSONUtil.LoadJson("Test")), "Steps", "Given");
        }
    }
}
