using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AutomationFramework.Core.Utilities;

namespace UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoSteps
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;

        public BlazeDemoSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _scenarioContext = scenarioContext;
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
                _wait.Until(ExpectedConditions.TitleIs(expectedTitle));
                Assert.That(_driver.Title, Is.EqualTo(expectedTitle));
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, _scenarioContext.ScenarioInfo.Title);
                throw new AssertionException($"Expected title: {expectedTitle}, but got: {_driver.Title}", ex);
            }
        }
    }
}