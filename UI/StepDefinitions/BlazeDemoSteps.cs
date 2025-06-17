using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoSteps
    {
        private readonly IWebDriver _driver;

        public BlazeDemoSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
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
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected <{expectedTitle}> but found <{actualTitle}>");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, "TestFailure");
                throw new Exception($"Assertion failed: {ex.Message}", ex);
            }
        }
    }
}