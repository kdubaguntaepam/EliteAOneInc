using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class VerifyPageTitleSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public VerifyPageTitleSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            try
            {
                string actualTitle = _driver.Title;
                Assert.AreEqual(expectedTitle, actualTitle, $"Expected title to be '{expectedTitle}' but was '{actualTitle}'");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, _scenarioContext.ScenarioInfo.Title);
                Assert.Fail($"Error verifying page title: {ex.Message}");
            }
        }
    }
}
