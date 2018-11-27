using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    public abstract class BasePageObject
    {
        private string url;

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

        public IWebDriver Driver { get; set; }

        public BasePageObject()
        {
            this.Driver = WebDriverBase.Driver;
            try
            {
                this.WaitForElements();
            }
            catch (Exception ex)
            {
                throw new WebDriverException(string.Format("The page failed to load : " + ex.Message));
            }
        }

        public BasePageObject(IWebDriver driver)
        {
            this.Driver = driver;
            try
            {
                this.WaitForElements();
            }
            catch (Exception ex)
            {
                throw new WebDriverException(string.Format("The page failed to load : " + ex.Message));
            }
        }

        public virtual void WaitForElements(int timeInSeconds = 30)
        {
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
        }

        public void WaitElapsedTime(uint mSec)
        {
            Boolean isReady = false;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (!isReady)
            {
                if (s.ElapsedMilliseconds > mSec)
                    isReady = true;
            }
            s.Stop();
        }


    }
}