using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.WebDriver
{
	class EventedWebDriver
	{
		private EventFiringWebDriver driver;

		public EventedWebDriver(IWebDriver driver)
		{
			this.Driver = new EventFiringWebDriver(driver);
		}

		public EventFiringWebDriver Driver
		{
			get
			{
				return this.driver;
			}

			set
			{
				this.driver = value;
			}
		}
	}
}
