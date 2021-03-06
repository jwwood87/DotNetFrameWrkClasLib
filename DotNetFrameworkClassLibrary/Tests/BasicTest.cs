﻿using DotNetFrameworkClassLibrary.Tests.Utilities;
using DotNetFrameworkClassLibrary.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace DotNetFrameWrkClasLib.Tests
{
	class BasicTest : WebDriverBase
	{
        UrlNavigation urlNavigation = new UrlNavigation();

		[Test]
		public void RunWebDriver()
		{

            urlNavigation.GoToBaseUrl();
			Driver.FindElement(By.Id("search_form_input_homepage")).Clear();
			Driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("Englewood, CO");
			Driver.FindElement(By.Id("search_button_homepage")).Click();
			Thread.Sleep(1000);
			Console.WriteLine("We got to the web page");
		}
	}
}
