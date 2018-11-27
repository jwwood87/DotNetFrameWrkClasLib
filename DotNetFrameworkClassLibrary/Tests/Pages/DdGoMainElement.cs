using DotNetFrameworkClassLibrary.WebDriver;
using OpenQA.Selenium;

namespace DotNetFrameworkClassLibrary.Tests.Pages
{
    class DdGoMainElement : BasePageHelper
    {
        public readonly Element SearchFormInput = new Element("SearchFormInput", By.Id("search_form_input_homepage"));
        public readonly Element SearchFormButton = new Element("SearchFormButton", By.Id("search_button_homepage"));
    }
}
