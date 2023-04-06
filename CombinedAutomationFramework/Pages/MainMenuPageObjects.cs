using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFramework.Pages
{
    public class MainMenuPageObjects
    {
        public static By mainMenuItemList = By.XPath("//*[contains(@id,'example-navbar')]//ul[contains(@class,'navbar-nav')]/li/a");
        public static By myAccountDropDownOptions = By.XPath("//ul[@class='dropdown-menu']/li/a");
    }
}
