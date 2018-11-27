using DotNetFrameworkClassLibrary.WebDriver;
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

        public void ClickSearchFormInput()
        {
            WaitElapsedTime(1000);
            ddGoMainElement.SearchFormInput.Click();
        }
    }
}
