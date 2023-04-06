using BoDi;
using GenericFrameworkComponent.BufferUtil;
using GenericFrameworkComponent.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace GenericFrameworkComponent.UIFrameworkUtilities
{
    public class DriverFactory
    {
        public static IWebDriver? driver;
        static ChromeOptions? chromeOptions = null;
        static EdgeOptions? edgeOptions = null;
        static string remotePlatformName = ExcelUtil.cs.cloudProvider.ToUpper();

        public static void setup(String platform, String browser)
        {
            if (platform.Equals(CommonConstants.platformRemote.ToUpper()))
            {
                if (remotePlatformName.Equals(CommonConstants.platformRemoteBrowserstack.ToUpper()))
                {
                    Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
                    browserstackOptions.Add("os", ExcelUtil.cs.os.Split(' ')[0]);
                    browserstackOptions.Add("osVersion", ExcelUtil.cs.os.Split(' ')[1]);
                    browserstackOptions.Add("browserVersion", CommonConstants.browserRemoteVersion);
                    browserstackOptions.Add("projectName", ExcelUtil.cs.projectName);
                    browserstackOptions.Add("sessionName", BufferUtilSuiteLevel.scenarioName);
                    browserstackOptions.Add("local", "false");
                    browserstackOptions.Add("seleniumVersion", CommonConstants.remoteSeleniumVersion);
                    browserstackOptions.Add("userName", ExcelUtil.cs.hostUsername);
                    browserstackOptions.Add("accessKey", ExcelUtil.cs.key);
                    browserstackOptions.Add("buildName", ExcelUtil.cs.buildNumber);

                    if (browser.Equals(CommonConstants.browserChrome.ToUpper()))
                    {
                        chromeOptions = new ChromeOptions();

                        browserstackOptions.Add("browserName", CommonConstants.browserChrome);
                        chromeOptions.AddAdditionalOption("bstack:options", browserstackOptions);

                        driver = new RemoteWebDriver(
                          new Uri(ExcelUtil.cs.cloudProviderURL), chromeOptions);
                    }
                    else if (browser.Equals(CommonConstants.browserEdge.ToUpper()))
                    {
                        edgeOptions = new EdgeOptions();

                        browserstackOptions.Add("browserName", CommonConstants.browserEdge);
                        edgeOptions.AddAdditionalOption("bstack:options", browserstackOptions);

                        driver = new RemoteWebDriver(
                          new Uri(ExcelUtil.cs.cloudProviderURL), edgeOptions);
                    }
                }
                else if (remotePlatformName.Equals(CommonConstants.platformRemoteSauceLabs.ToUpper()))
                {
                    Dictionary<string, object> sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("build", ExcelUtil.cs.buildNumber);
                    sauceOptions.Add("name", BufferUtilSuiteLevel.scenarioName);

                    var uri = new Uri("https://" + ExcelUtil.cs.hostUsername + ":" + ExcelUtil.cs.key + "@" + ExcelUtil.cs.cloudProviderURL);

                    if (browser.Equals(CommonConstants.browserChrome.ToUpper()))
                    {
                        chromeOptions = new ChromeOptions();

                        chromeOptions.PlatformName = ExcelUtil.cs.os;
                        chromeOptions.BrowserVersion = CommonConstants.browserRemoteVersion;
                        chromeOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        driver = new RemoteWebDriver(uri, chromeOptions);
                    }
                    else if (browser.Equals(CommonConstants.browserEdge.ToUpper()))
                    {
                        edgeOptions = new EdgeOptions();

                        edgeOptions.PlatformName = ExcelUtil.cs.os;
                        edgeOptions.BrowserVersion = CommonConstants.browserRemoteVersion;
                        edgeOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        driver = new RemoteWebDriver(uri, edgeOptions);
                    }
                }
                else
                {
                    throw new Exception("Remote platform is not properly defined.");
                }
            }
            else if (platform.Equals(CommonConstants.platformLocal.ToUpper()))
            {
                switch (browser)
                {
                    case CommonConstants.browserChrome:
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        chromeOptions = new ChromeOptions();
                        chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case CommonConstants.browserEdge:
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        edgeOptions = new EdgeOptions();
                        edgeOptions.PageLoadStrategy= PageLoadStrategy.Eager;
                        driver = new EdgeDriver(edgeOptions);
                        break;
                    default:
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        chromeOptions = new ChromeOptions();
                        chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                        driver = new ChromeDriver();
                        break;
                }
            }
            else
            {
                throw new Exception("Platform is not properly defined.");
            }
            LogUtil.infoLog("Starting test case execution with platform: " + platform + " and browser: " + browser);
            driver.Manage().Window.Maximize();
        }

        public static void tearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            else
            {
                throw new Exception("Webdriver is already closed.");
            }
        }
    }
}
