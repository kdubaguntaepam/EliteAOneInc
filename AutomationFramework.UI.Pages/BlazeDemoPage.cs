using OpenQA.Selenium;

namespace AutomationFramework.UI.Pages
{
    public class BlazeDemoPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://blazedemo.com/";

        public BlazeDemoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}
