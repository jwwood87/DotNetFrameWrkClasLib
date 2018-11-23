using DotNetFrameworkClassLibrary.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    class WebDriverBase : TestBase
    {
        public Config config = new Config();

        public static IWebDriver Driver
        {
            get { return TestData.Driver; }
            set { TestData.Driver = value; }
        }

        [SetUp]
        public virtual void SetUp()
        {
            System.Console.WriteLine("Entering WebDriverBase Setup");
            //LaunchBrowser();
        }

        [TearDown]
        public override void TearDownTestBase()
        {
            System.Console.WriteLine("Entering WebDriverBase TearDownTestBase");
            QuitBrowser();
        }

        /// <summary>
        ///     Opens the Browser
        /// </summary>
        public void LaunchBrowser()
        {
            Driver = new ChromeDriver();
            System.Console.WriteLine("Browser Launched");
        }

        /// <summary>
        ///     Closes the active Browser
        /// </summary>
        public void QuitBrowser()
        {
            Driver.Quit();
            System.Console.WriteLine("Browser Closed");
        }
    }
}
