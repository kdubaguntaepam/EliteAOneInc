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

        [Given(@"I navigate to "(.*)"")]
        public void GivenINavigateTo(string url)
        {
            _driver = (IWebDriver)_scenarioContext["WebDriver"];
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the title should be "(.*)"")]
        public void ThenTheTitleShouldBe(string expectedTitle)
        {
            try
            {
                string actualTitle = _driver.Title;
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Expected page title does not match the actual title.");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, "VerifyPageTitle");
                throw new Exception("Validation failed: " + ex.Message);
            }
        }
    }
}