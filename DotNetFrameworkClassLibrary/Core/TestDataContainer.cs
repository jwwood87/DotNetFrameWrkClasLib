using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.Core
{
    public class TestDataContainer
    {
        public string testName;
        public IWebDriver Driver { get; set; }

        public TestDataContainer(string name)
        {
            testName = name;

        }
    }
}
