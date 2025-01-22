using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UI.Pages
{
    public class BlazeDemoHomePage
    {
        private readonly IWebDriver _driver;

        public BlazeDemoHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}