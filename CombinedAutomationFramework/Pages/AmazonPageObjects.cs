using Microsoft.AspNetCore.Http;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.Pages
{
    public class AmazonPageObjects
    {
        public static By navigateSignInButton = By.XPath("//*[@id='nav-tools']/a[2]");
        public static By emailField = By.XPath("//*[@id='ap_email']");
        public static By passwordField = By.XPath("//*[@id='ap_password']");
        public static By continueButton = By.XPath("//input[@id='continue']");
        public static By signInButton = By.XPath("//*[@id='signInSubmit']");
        public static By invalidLoginMessage = By.XPath("//*[text()=\"There was a problem\"]");
    }
}
