using OpenQA.Selenium;

namespace AutomationFramework.UI.BusinessLogic
{
    public class BlazeDemoPageTitleBusinessLogic
    {
        private readonly IWebDriver _driver;

        public BlazeDemoPageTitleBusinessLogic(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}
