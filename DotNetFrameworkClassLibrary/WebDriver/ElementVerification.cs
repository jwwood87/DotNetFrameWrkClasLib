using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFrameworkClassLibrary.WebDriver
{
    public class ElementVerification
    {
        private const string ErrorMessage = "{0}: {1}({2}): {3} after {4} seconds";
        private readonly Element element;
        private readonly bool failTest;
        private readonly bool isTrue = true;
        private bool condition;
        private string message;
        private string notMessage;
        private int timeoutSec;

        public ElementVerification(Element elementParam, int timeoutSecParam, bool failTestParam = false, bool isTrueParam = true)
        {
            this.element = elementParam;
            this.timeoutSec = timeoutSecParam;
            this.failTest = failTestParam;
            this.isTrue = isTrueParam;
        }

        public Element Visible()
        {
            this.message = "is visible";
            this.notMessage = "not visible";
            var then = DateTime.Now.AddSeconds(this.timeoutSec);
            for (var now = DateTime.Now; now < then; now = DateTime.Now)
            {
                this.condition = this.element.Displayed;
                if (this.condition == this.isTrue)
                {
                    Console.WriteLine("!--Verification Passed");
                    return this.element;
                }
            }

            this.VerificationFailed();
            return this.element;
        }

        private void VerificationFailed(string message = "")
        {
            Console.WriteLine("Verification failed");
        }
    }
}
