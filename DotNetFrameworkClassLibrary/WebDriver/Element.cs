using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    public class Element : WebDriverBase, IWrapsElement
    {
        private By by;
        private string name;
        private string pageObjectName = string.Empty;
        private int timeoutSec;
        private Element root;
        private IWebElement element;
		private IWrapsElement wrapsElement;
        private IEnumerable<Element> elements1;

		protected IWebElement Element_
        {
            get
            {
                this.Element1 = this.GetElement();
                return this.Element1;
            }

            set
            {
                this.Element1 = value;
            }
        }

        protected IWebElement Element1
        {
            get
            {
                return this.element;
            }

            set
            {
                this.element = value;
            }
        }

        public string Name1
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Name
        {
            get
            {
                return this.Name1;
            }

            set
            {
                this.Name1 = value;
            }
        }

        public By By
        {
            get
            {
                return this.by;
            }

            set
            {
                this.by = value;
            }
        }

		public IWebDriver Driver { get; set; }

		public IWebDriver WrappedDriver
		{
			get { return this.Driver; }
			private set { this.Driver = value; }
		}

		public IWebElement WrappedElement
        {
            get { return this.Element_; }
            private set { this.Element_ = value; }
        }

		public Element(IWebElement element)
        {
            this.Element_ = element;
        }

		[SetUp]
		public void Setup()
		{
			this.Driver = WebDriverBase.Driver;
		}

		/// <summary>
		///     Construct an element
		/// </summary>
		/// <param name="name">Human readable name of the element</param>
		/// <param name="locator">By locator</param>
		public Element(string name, By locator)
        {
            this.Name = name;
            this.By = locator;
        }

        public Element(IWebElement element, By by)
        {
            this.Element_ = element;
            this.By = by;
        }

        public Element(By locator)
        {
            this.By = locator;
        }

        public virtual IWebElement GetElement()
        {
            try
            {
                return this.Element1;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Couldn't find the elemnt");
                throw new NoSuchElementException(e.Message);
            }
        }

        public IWebElement FindElement(By by)
        {
            var then = DateTime.Now.AddSeconds(30);
            for (var now = DateTime.Now; now < then; now = DateTime.Now)
            {
                try
                {
                    Console.WriteLine($"Looking for {0} of {1}", this.Name, this.By);
                    var eles = this.Element_.FindElements(by);
                    if (eles.Count > 0)
                    {
                        return eles[0];
                    }
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("Exception: stale" + e.Message);
                }
            }

            throw new NoSuchElementException(
                $"Child ({by}) of Element {this.Name} ({this.By}) was not present after 30 seconds");
        }

        public Element Click()
        {
            try
            {
				this.Element_.Click();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught: This Operation is Invalid\n" + e);
            }
            return this;
        }

        public ElementVerification Verify()
        {
            return new ElementVerification(this, 30, false);
        }

        public bool Present
        {
            get
            {
                try
                {
                    return this.Element_.Enabled;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Exception caught: No such element found\n" + e);
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("Exception caught: The Element Referenced is Stale\n" + e);
                    return false;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught: This Operation is Invalid\n" + e);
                    return false;
                }
            }
        }

        public bool Displayed
        {
            get
            {
                try
                {
                    if (!this.Present)
                    {
                        return false;
                    }

                    return this.Element_.Displayed;
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Exception: No such element" + e);
                    return false;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("Exception:The element is stale" + e);
                    return false;
                }
            }
        }

		public IWebDriver Driver1 { get => Driver2; set => Driver2 = value; }
		public IWebDriver Driver2 { get; set; }
	}
}
