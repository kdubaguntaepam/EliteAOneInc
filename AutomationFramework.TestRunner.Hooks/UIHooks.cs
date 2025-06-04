using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.TestRunner.Hooks
{
    [Binding]
    public class UIHooks
    {
        private IWebDriver _driver;

        [BeforeScenario(@"UI")]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            ScenarioContext.Current["Driver"] = _driver;
        }

        [AfterScenario(@"UI")]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScreenshotHelper.TakeScreenshot(_driver, ScenarioContext.Current.ScenarioInfo.Title);
            }
            _driver.Quit();
        }
    }
}
