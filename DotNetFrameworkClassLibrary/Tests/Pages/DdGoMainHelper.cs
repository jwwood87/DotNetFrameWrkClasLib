using global::DotNetFrameworkClassLibrary.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetFrameworkClassLibrary.Tests.Pages
{
	class DdGoMainHelper : BasePageHelper
	{
		DdGoMainElement ddGoMainElement = new DdGoMainElement();
        public readonly Element SearchFormInput1 = new Element("SearchFormInput", By.Id("search_form_input_homepage"));
        public readonly Element SearchFormButton1 = new Element("SearchFormButton", By.Id("search_button_homepage"));
        //public IWebDriver Driver { get; set; }

        public void ClickSearchFormInput()
		{
			this.Driver = WebDriverBase.Driver;
			WaitElapsedTime(1000);
            SearchFormButton1.Click();
		}

		public void EnterSearchFormText(string text)
		{
			ddGoMainElement.SearchFormInput.GetElement();
		}
	}
}
