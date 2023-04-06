using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.Pages
{
    public class LoginPageObjects
    {
        public static By UsernameField = By.XPath("//input[contains(@id,'txtUserName')]");
        public static By passwordField = By.XPath("//input[contains(@id,'txtPassword')]");
        public static By loginButton = By.XPath("//div[contains(@id,'btnLogin')]//span");
        public static By loginErrorMessage = By.XPath("//span[contains(@id,'lblError')]");
    }
}
