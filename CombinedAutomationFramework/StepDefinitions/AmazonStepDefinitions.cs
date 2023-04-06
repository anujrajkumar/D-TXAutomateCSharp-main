using GenericFrameworkComponent.UIFrameworkUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UIAutomationFramework.Modules;
using UIAutomationFramework.Pages;

namespace UIAutomationFramework.StepDefinitions
{
    [Binding]
    public class AmazonStepDefinitions
    {
        [Given(@"Navigate to Amazon login page")]
        public void GivenNavigateToAmazonLoginPage()
        {
           AmazonModule.gotoLoginPage();
        }

        [When(@"Entering Amazon login credential from '([^']*)'")]
        public void WhenEnteringAmazonLoginCredentialFrom(string testDataName)
        {
            AmazonModule.enterLoginCredentials(testDataName);
        }

        [When(@"Click on continue button")]
        public void WhenClickOnContinueButton()
        {
            AmazonModule.clickContinueButton();
        }

        [When(@"Entering Amazon login credential password from '([^']*)'")]
        public void WhenEnteringAmazonLoginCredentialPasswordFrom(string testDataName)
        {
            AmazonModule.enterLoginCredentialsPassword(testDataName);
        }

        [When(@"Click amazon login button")]
        public void WhenClickAmazonLoginButton()
        {
            AmazonModule.clickSignInButton();
        }

        [Then(@"Validating the amazon login status")]
        public void ThenValidatingTheAmazonLoginStatus()
        {
            if (WebDriverUtils.waitForVisibleBool(AmazonPageObjects.invalidLoginMessage))
            {
                WebDriverUtils.catchBlockWithFailAndStop("Login page is displaying error message.");
            }
        } 
    }
}
