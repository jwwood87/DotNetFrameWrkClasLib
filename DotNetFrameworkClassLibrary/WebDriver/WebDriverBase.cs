using DotNetFrameworkClassLibrary.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    public class WebDriverBase : TestBase
    {
        public static IWebDriver Driver { get; set; }
        private Config _config = new Config();

        [SetUp]
        public override void TestBaseSetUp()
        {
            System.Console.WriteLine(DateTime.Now.ToString() + ": Entering WebDriverBase Setup.");
            LaunchBrowser();
        }

        [TearDown]
        public override void TestBaseTearDown()
        {
            System.Console.WriteLine(DateTime.Now.ToString() + ": Entering WebDriverBase TearDown.");
            QuitBrowser();
        }

        /// <summary>
        ///     Opens the Browser
        /// </summary>
        public void LaunchBrowser()
        {
            Driver = new WebDriverBrowser().LaunchSelectedBrowser(WebDriverBrowser.GetBrowserFromString(_config.GetBrowser()));
            System.Console.WriteLine("Browser Launched");
        }

        /// <summary>
        ///     Closes the active Browser
        /// </summary>
        public void QuitBrowser()
        {
            System.Console.WriteLine("Browser Closed");
            Driver.Quit();
        }

    }
}
