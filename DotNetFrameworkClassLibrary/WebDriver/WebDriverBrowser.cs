﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Linq;

namespace DotNetFrameworkClassLibrary.WebDriver
{
	class WebDriverBrowser : WebDriverBase
	{
		private const string BrowserLanguageIndicator = "BrowserLanguage_";
		private IWebDriver driver;

		public enum Browser
		{
			Firefox,
			Chrome,
			IE,
			Safari,
			PhantomJS,
			Android,
			IPhone,
			IPad,
			None
		}

		public IWebDriver Driver
		{
			get
			{return driver;}

			set
			{driver = value;}
		}

		public static Browser GetBrowserFromString(string name)
		{
			return (Browser)Enum.Parse(typeof(Browser), name);
		}

		public IWebDriver LaunchBrowser(Browser browser)
		{
			switch (browser)
			{
				case Browser.IE:
					Driver = StartIEBrowser();
					break;
				case Browser.Chrome:
					Driver = StartChromeBrowser();
					break;
				case Browser.Safari:
					Driver = StartSafariBrowser();
					break;
				default:
					Driver = StartFirefoxBrowser();
					break;
			}
			Driver.Manage().Cookies.DeleteAllCookies();
			//SetBrowserSize();
			var edriver = new EventedWebDriver(Driver);

			return edriver.Driver;
		}

		public IWebDriver StartFirefoxBrowser()
		{
			var firefoxOptions = new FirefoxOptions();
			//string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", string.Empty).Replace(@"\bin\Release", string.Empty);
			//string temppath = "bin\\" + ConfigurationManager.AppSettings["Environment"]; // remove texts after the Project name
			//string finalpath = $"{path}\\geckodriver.exe";
			//System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", finalpath);
			//firefoxOptions.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
			string browserLanguage = CheckForBrowserLanguageTestCategoryUsed();
			if (!string.IsNullOrWhiteSpace(browserLanguage)) firefoxOptions.AddArguments($"--lang={browserLanguage}");
			return new FirefoxDriver(firefoxOptions);
		}

		public IWebDriver StartChromeBrowser()
		{
			var options = new ChromeOptions();

			//// This line disables all the Chrome Browser Extensions. We would need future modification, if we need to enable them for some tests.
			options.AddArguments("--disable-extensions");

			//Add the WebDriver proxy capability.
			options.AddArgument("--user-agent=arrowgatlingperformanceautomation");

			string browserLanguage = CheckForBrowserLanguageTestCategoryUsed();
			if (!string.IsNullOrWhiteSpace(browserLanguage)) options.AddArguments($"--lang={browserLanguage}");

			return new ChromeDriver(options);
		}

		private static string CheckForBrowserLanguageTestCategoryUsed()
		{
			var contextProperties = TestContext.CurrentContext?.Test?.Properties;
			if (contextProperties != null && contextProperties.ContainsKey("Category"))
			{
				var testCategory = contextProperties["Category"]?.Cast<string>().FirstOrDefault(c => c.Contains(BrowserLanguageIndicator));
				if (testCategory != null)
				{
					var browserLanguage = testCategory.Replace(BrowserLanguageIndicator, "");
					return browserLanguage;
				}
			}
			return string.Empty;
		}

		public IWebDriver StartIEBrowser()
		{
			var options = new InternetExplorerOptions();
			options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
			options.IgnoreZoomLevel = true;
			options.EnsureCleanSession = true;
			options.EnablePersistentHover = true;

			return new InternetExplorerDriver(options);
		}

		public IWebDriver StartSafariBrowser()
		{
			var options = new SafariOptions();
			return new SafariDriver(options);
		}

//		public DesiredCapabilities GetCapabilitiesForBrowser(Browser browser)
//		{
//			switch (browser)
//			{
//				case Browser.PhantomJS:
//					return DesiredCapabilities.PhantomJS();
//				case Browser.IE:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.InternetExplorer();
//#pragma warning restore CS0618 // Type or member is obsolete
//				case Browser.Chrome:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.Chrome();
//#pragma warning restore CS0618 // Type or member is obsolete
//				case Browser.Safari:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.Safari();
//#pragma warning restore CS0618 // Type or member is obsolete
//				case Browser.Android:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.Android();
//#pragma warning restore CS0618 // Type or member is obsolete
//				case Browser.IPhone:
//#pragma warning disable CS0618 // Type or member is obsolete
//					var capabilities = DesiredCapabilities.IPhone();
//#pragma warning restore CS0618 // Type or member is obsolete
//					capabilities.SetCapability("device", "iphone");
//					capabilities.SetCapability("app", "safari");
//					return capabilities;
//				case Browser.IPad:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.IPad();
//#pragma warning restore CS0618 // Type or member is obsolete
//				case Browser.Firefox:
//				default:
//#pragma warning disable CS0618 // Type or member is obsolete
//					return DesiredCapabilities.Firefox();
//#pragma warning restore CS0618 // Type or member is obsolete
//			}
//		}

		/// <summary>
		///     This method sets the default browser size 
		/// </summary>
		//private void SetBrowserSize()
		//{
		//	var resolution = config.Settings.RunTimeSetting.BrowserResolution;
		//	if (resolution.Contains("Default"))
		//	{
		//		Driver.Manage().Window.Maximize();
		//	}
		//	else
		//	{
		//		Driver.Manage().Window.Size = Common.GetSizeFromResolution(resolution);
		//	}
		//}
	}
}