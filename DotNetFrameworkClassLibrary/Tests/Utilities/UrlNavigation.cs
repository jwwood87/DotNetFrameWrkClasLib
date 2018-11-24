using DotNetFrameworkClassLibrary.Core;
using DotNetFrameworkClassLibrary.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.Tests.Utilities
{
    public class UrlNavigation : WebDriverBase
    {
        private Config _config = new Config();

        public void GoToArrowDotCom()
        {
            Driver.Navigate().GoToUrl(_config.GetBaseUrl());
        }
    }
}
