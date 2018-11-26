using DotNetFrameworkClassLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    class BasePageHelper : BasePageObject
    {
        private Config _config;

        public void VerifyElementVisible(Element element)
        {
            element.Verify().Visible();
        }

    }
}
