using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;

namespace UI.StepDefinitions
{
    [Binding]
    public class VerifyBlazeDemoTitleSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        public VerifyBlazeDemoTitleSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
        }

        [Given(@"I navigate to \"(.*)\"")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be \"(.*)\"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            try
            {
                string actualTitle = _driver.Title;
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected {{expectedTitle}} but found {{actualTitle}}");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, _scenarioContext.ScenarioInfo.Title);
                throw new Exception($"Assertion failed: {{ex.Message}}");
            }
        }
    }
}
