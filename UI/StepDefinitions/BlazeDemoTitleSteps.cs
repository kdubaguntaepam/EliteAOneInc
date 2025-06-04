using OpenQA.Selenium;
using TechTalk.SpecFlow;
using EliteAOneInc.Core.Utilities;
using EliteAOneInc.TestRunner.Hooks;

namespace EliteAOneInc.UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoTitleSteps
    {
        private readonly IWebDriver _driver;

        public BlazeDemoTitleSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to "(.*)"")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be "(.*)"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            try
            {
                string actualTitle = _driver.Title;
                if (actualTitle != expectedTitle)
                {
                    ScreenshotHelper.TakeScreenshot(_driver, "BlazeDemoTitleValidationFailure");
                }
                Assert.AreEqual(expectedTitle, actualTitle);
            }
            catch (Exception ex)
            {
                ScreenshotHelper.TakeScreenshot(_driver, "BlazeDemoTitleException");
                throw new Exception($"An error occurred while validating the page title: {ex.Message}");
            }
        }
    }
}