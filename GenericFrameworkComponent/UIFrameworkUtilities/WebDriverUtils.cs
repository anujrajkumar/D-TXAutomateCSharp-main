using BoDi;
using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.UIFrameworkUtilities
{
    public class WebDriverUtils : DriverFactory
    {
        static IWebElement? element;
        static ReadOnlyCollection<IWebElement>? elementList;

        public static void catchBlockWithFailAndStop(Exception e, string specificReasonPart)
        {
            BufferUtilSuiteLevel.exception = e;
            string errorMessage = specificReasonPart + e.Message;
            LogUtil.ErrorLog(errorMessage);
            ExtentUtil.LogFail(errorMessage);
            Assert.Fail(errorMessage);
        }

        public static void catchBlockWithFailAndStop(string specificReasonPart)
        {
            LogUtil.ErrorLog(specificReasonPart);
            ExtentUtil.LogFail(specificReasonPart);
            Assert.Fail(specificReasonPart);
        }

        public static void GetURL(string URL)
        {
            try
            {
                driver.Navigate().GoToUrl(URL);
                LogUtil.infoLog("Navigated to URL: " + URL);
                ExtentUtil.LogPass("Navigated to URL: " + URL);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to navigate to URL.");
            }
        }

        public static void getCurrentURL()
        {
            try
            {
                string currentURL = driver.Url;
                LogUtil.infoLog("Current page URL: " + currentURL);
                ExtentUtil.LogPass("Current page URL: " + currentURL);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find the current URL.");
            }
        }

        public static void waitForClickable(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static void waitForClickable(IWebElement webElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static void waitForClickable(By locator, double waitTIme)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTIme));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static void waitForClickable(IWebElement webElement, double waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static void waitForVisible(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static void waitForVisible(By locator, double waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find element due to reason: ");
            }
        }

        public static Boolean waitForVisibleBool(By locator)
        {
            Boolean flag;

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                flag = true;
            }
            catch (Exception e)
            {
                LogUtil.ErrorLog(e.Message);
                flag = false;
            }

            return flag;
        }

        public static Boolean waitForVisibleBool(By locator, double waitTime)
        {
            Boolean flag;

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                flag = true;
            }
            catch (Exception e)
            {
                LogUtil.ErrorLog(e.Message);
                flag = false;
            }

            return flag;
        }

        public static void listOfElements(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                elementList = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(driver.FindElements(locator)));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static void listOfElements(By locator, double waitTime)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                elementList = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(driver.FindElements(locator)));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static void inputText(By locator, string inputText)
        {
            string logStep = "Entering Text: " + inputText;
            try
            {
                waitForClickable(locator);
                element.SendKeys(inputText);
                LogUtil.infoLog(logStep);
                ExtentUtil.LogPass(logStep);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static void clickElement(By locator, String elementName)
        {
            string logStep = "Clicking on element: " + elementName;
            try
            {
                waitForClickable(locator);
                element.Click();
                LogUtil.infoLog(logStep);
                ExtentUtil.LogPass(logStep);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static string dateTimeFolderPatterName()
        {
            string dateTime = DateTime.Now.ToString().Replace(" ", "-").Replace("/", "-").Replace(":", "-");
            return dateTime;
        }

        public static string ScreenShotCapture(string logStep)
        {
            try
            {
                BufferUtilMethodLevel.screenshotFileName = "Screenshot_" + WebDriverUtils.dateTimeFolderPatterName() + ".jpeg";
                BufferUtilSuiteLevel.screenshotPath = FileFolderUtil.screenshotFolderCompletePath() + BufferUtilMethodLevel.screenshotFileName;
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(BufferUtilSuiteLevel.screenshotPath, ScreenshotImageFormat.Jpeg);
                LogUtil.infoLog("Screenshot taken and saved as: " + BufferUtilSuiteLevel.screenshotPath);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
            return BufferUtilSuiteLevel.screenshotPath;
        }

        public static Boolean compareTexts(string actual, string expected)
        {
            Boolean flag;
            try
            {
                if (actual.Equals(expected))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorLog(e.Message);
                flag = false;
            }
            return flag;
        }

        public static string textFromElement(By locator)
        {
            string textFromElement = null;
            try
            {
                waitForVisible(locator);
                textFromElement = element.Text;
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find Text from element due to reason: ");
            }
            return textFromElement;
        }

        public static string textFromElement(IWebElement webElement)
        {
            string textFromElement = null;
            try
            {
                waitForClickable(webElement);
                textFromElement = element.Text;
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to find Text from element due to reason: ");
            }
            return textFromElement;
        }

        public static void validateElementText(By locator, string textToBePresent)
        {
            Boolean flag;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                flag = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, textToBePresent));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static void validateElementText(IWebElement webElement, string textToBePresent)
        {
            Boolean flag;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CommonConstants.DEFAULT_WAIT_TIME));
                flag = wait.Until(ExpectedConditions.TextToBePresentInElementValue(webElement, textToBePresent));
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }

        public static void pressTabKey(By locator)
        {
            try
            {
                waitForVisible(locator);
                element.SendKeys(Keys.Tab);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because: ");
            }
        }

        public static void pressEnterKey(By locator)
        {
            try
            {
                waitForVisible(locator);
                element.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because: ");
            }
        }

        public static void selectByIndex(By locator, int index)
        {
            try
            {
                waitForVisible(locator);
                SelectElement dropDown = new SelectElement(element);
                dropDown.SelectByIndex(index);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to select option because: ");
            }
        }

        public static void selectByValue(By locator, string value)
        {
            try
            {
                waitForVisible(locator);
                SelectElement dropDown = new SelectElement(element);
                dropDown.SelectByValue(value);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to select option because: ");
            }
        }

        public static void selectByVisibleText(By locator, string visibleText)
        {
            try
            {
                waitForVisible(locator);
                SelectElement dropDown = new SelectElement(element);
                dropDown.SelectByText(visibleText);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to select option because: ");
            }
        }

        public static Boolean validateSelectedOption(By locator, string optionToValidate)
        {
            Boolean result = false;
            try
            {
                waitForVisible(locator);
                SelectElement dropDown = new SelectElement(element);
                string selectedOption = textFromElement(dropDown.SelectedOption);
                if (compareTexts(selectedOption, optionToValidate))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to get selected option because: ");
            }
            return result;
        }

        public static void acceptBrowserAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to accept alert because: ");
            }
        }

        public static string alertText()
        {
            string alertText = null;
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alertText = alert.Text;
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to gather alert text because: ");
            }

            return alertText;
        }

        public static void switchToWindowByName(String windowName)
        {
            try
            {
                driver.SwitchTo().Window(windowName);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to window because: ");
            }
        }

        public static void switchToDefaultWindow()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to default window because: ");
            }
        }

        public static void switchToIFrameByIndex(int frameIndex)
        {
            try
            {
                driver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to iFrame because: ");
            }
        }

        public static void switchToIFrameByName(string frameName)
        {
            try
            {
                driver.SwitchTo().Frame(frameName);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to iFrame because: ");
            }
        }

        public static void switchToIFrameByElement(IWebElement webElement)
        {
            try
            {
                driver.SwitchTo().Frame(webElement);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to iFrame because: ");
            }
        }

        public static void switchToIFrameByLocator(By locator)
        {
            try
            {
                waitForVisible(locator);
                driver.SwitchTo().Frame(element);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to iFrame because: ");
            }
        }

        public static void switchToIFrameByLocator(By locator, double waitTime)
        {
            try
            {
                waitForVisible(locator, waitTime);
                driver.SwitchTo().Frame(element);
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed to failed to switch to iFrame because: ");
            }
        }

        public static void markTCPassInBrowserStack()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Test case passed\"}}");
        }

        public static void markTCFailInBrowserStack(string message)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" " + message + " \"}}");
        }

        public static void markTestCaseStatusSauceLabs(Boolean isPassed)
        {
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static void clickListOption(By locator, string optionToCLick)
        {
            listOfElements(locator);
            try
            {
                if (elementList.Count > 0)
                {
                    for (int i = 0; i < elementList.Count; i++)
                    {
                        waitForClickable(elementList[i]);
                        LogUtil.infoLog("Menu option " + (i + 1) + " is " + element.Text);
                        if (element.Text.Equals(optionToCLick))
                        {
                            element.Click();
                            ExtentUtil.LogPass("Clicked on option: " + optionToCLick);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                catchBlockWithFailAndStop(e, "Failed because ");
            }
        }
    }
}
