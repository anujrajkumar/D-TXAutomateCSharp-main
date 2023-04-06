using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.XWPF.UserModel;
using System;
using TechTalk.SpecFlow;
using UIAutomationFramework.Modules;
using UIProject.Modules;

namespace UIAutomationFramework.StepDefinitions
{
    [Binding]
    public class ThisIsTestFeature1StepDefinitions
    {
        [Given(@"Read data from sheet '([^']*)' in excel")]
        public void GivenReadDataFromSheetInExcel(string sheetName)
        {
            BufferUtilSuiteLevel.keyValuePairsForLoginSheet = ExcelUtil.getTestDataFromSheet(sheetName);
        }

        [Given(@"Navigate to application URL using data '([^']*)'")]
        public void GivenNavigateToApplicationURLUsingData(string testDataName)
        {
            CommonModule.navigateToURL(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.URL));
        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            LandingPageModule.clickMyAccountsOption();
            LandingPageModule.clickLoginOption();
            ExtentUtil.LogPass("Successfully Navigated to Login page.");
        }

        [When(@"Entering login credential from '([^']*)'")]
        public void WhenEnteringLoginCredentialFrom(string testDataName)
        {
            LoginPageModule.enterCredentials(ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Username),
                ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Password));
        }

        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            LoginPageModule.clickLoginButton();
        }

        [Then(@"Validating the login status")]
        public void ThenValidatingTheLoginStatus()
        {
            LoginPageModule.checkLoginStatus();
        }
    }
}
