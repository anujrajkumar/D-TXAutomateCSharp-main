using GenericFrameworkComponent.UIFrameworkUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationFramework.Pages;

namespace UIProject.Modules
{
    public class LoginPageModule
    {
        public static void enterCredentials(string Username, string Password)
        {
            WebDriverUtils.inputText(LoginPageObjects.UsernameField, Username);
            WebDriverUtils.inputText(LoginPageObjects.passwordField, Password);
        }

        public static void clickLoginButton()
        {
            WebDriverUtils.clickElement(LoginPageObjects.loginButton, "Login Button");
        }

        public static void checkLoginStatus()
        {
            if (WebDriverUtils.waitForVisibleBool(LoginPageObjects.loginErrorMessage))
            {
                WebDriverUtils.catchBlockWithFailAndStop("Login page is displaying error message.");
            }
        }
    }
}
