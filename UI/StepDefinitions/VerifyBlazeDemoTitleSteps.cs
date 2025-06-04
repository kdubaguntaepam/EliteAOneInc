using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class VerifyBlazeDemoTitleSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public VerifyBlazeDemoTitleSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
        }

        [Given(@"I navigate to '(.*)'")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be '(.*)'")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            try
            {
                string actualTitle = _driver.Title;
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected '{expectedTitle}' but found '{actualTitle}'");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, "VerifyBlazeDemoTitle");
                throw new Exception($"Assertion failed: {ex.Message}");
            }
        }

        [Then(@"the page title should not be '(.*)'")]
        public void ThenThePageTitleShouldNotBe(string expectedTitle)
        {
            try
            {
                string actualTitle = _driver.Title;
                Assert.That(actualTitle, Is.Not.EqualTo(expectedTitle), $"Expected title not to be '{expectedTitle}' but it was.");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, "VerifyBlazeDemoTitle");
                throw new Exception($"Assertion failed: {ex.Message}");
            }
        }
    }
}