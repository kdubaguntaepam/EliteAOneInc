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
        private readonly IWebDriver _driver;

        public VerifyPageTitleSteps(ScenarioContext scenarioContext)
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
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected page title to be '{expectedTitle}' but was '{actualTitle}'");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.TakeScreenshot(_driver, "PageTitleVerification");
                throw new Exception($"Error verifying page title: {ex.Message}");
            }
        }
    }
}