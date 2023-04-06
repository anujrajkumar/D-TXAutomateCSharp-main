using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.UIFrameworkUtilities;
using GenericFrameworkComponent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationFramework.Pages;

namespace UIAutomationFramework.Modules
{
    public class AmazonModule
    {
        public static void gotoLoginPage()
        {
            WebDriverUtils.clickElement(AmazonPageObjects.navigateSignInButton, "Navigate sign in button") ;
        }

        public static void enterLoginCredentials(string testDataName)
        {
            WebDriverUtils.inputText(AmazonPageObjects.emailField, 
                ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Username));
        }

        public static void enterLoginCredentialsPassword(string testDataName)
        {
            WebDriverUtils.inputText(AmazonPageObjects.passwordField,
                ExcelUtil.getTestDataUsingDataAndColumn(BufferUtilSuiteLevel.keyValuePairsForLoginSheet, testDataName, ColumnParam.Password));
        }

        public static void clickContinueButton()
        {
            WebDriverUtils.clickElement(AmazonPageObjects.continueButton, "Continue Button");
        }

        public static void clickSignInButton()
        {
            WebDriverUtils.clickElement(AmazonPageObjects.signInButton, "SignIn Button");
        }

        public static void validateLogin()
        {

        }
    }
}
