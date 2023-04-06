using GenericFrameworkComponent.UIFrameworkUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationFramework.Pages;

namespace UIAutomationFramework.Modules
{
    public class LandingPageModule
    {
        public static void clickMyAccountsOption()
        {
            WebDriverUtils.clickListOption(MainMenuPageObjects.mainMenuItemList, "MY ACCOUNT");
        }

        public static void clickLoginOption()
        {
            WebDriverUtils.clickListOption(MainMenuPageObjects.myAccountDropDownOptions, "LOGIN");
        }
    }
}
