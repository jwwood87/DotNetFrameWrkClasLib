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
        public IWebDriver Driver { get; set; }

        public void ClickSearchFormInput()
        {
            WaitElapsedTime(1000);
            ddGoMainElement.SearchFormInput.Click();
        }
    }
}
