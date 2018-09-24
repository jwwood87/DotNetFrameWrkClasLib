using DotNetFrameworkClassLibrary.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace DotNetFrameworkClassLibrary.Tests
{
	class BasicTest
	{
		public IWebDriver Driver;
		Config _config = new Config();

		[Test]
		public void RunWebDriver()
		{
			Driver = new ChromeDriver();
			Driver.Navigate().GoToUrl(_config.GetBaseUrl());
			Driver.FindElement(By.Id("search_form_input_homepage")).Clear();
			Driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("Englewood, CO");
			Driver.FindElement(By.Id("search_button_homepage")).Click();
			Thread.Sleep(1000);
			Driver.Quit();
			Console.WriteLine("We got to the web page");
		}
	}
}
