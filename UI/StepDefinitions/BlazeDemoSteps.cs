using TechTalk.SpecFlow;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;
using AutomationFramework.Core.Utilities;
using AutomationFramework.Core.Singleton;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

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

        [Given("I navigate to BlazeDemo page")]
        public void GivenINavigateToBlazeDemoPage()
        {
            var url = "https://blazedemo.com/";
            _driver.Navigate().GoToUrl(url);
        }

        [Then("the page title should be '(.*)'")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            try
            {
                var actualTitle = _driver.Title;
                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected page title to be '{expectedTitle}' but was '{actualTitle}'");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.CaptureScreenshot(_driver, "BlazeDemoPageTitleError");
                throw new AssertionException($"An error occurred while verifying the page title: {ex.Message}");
            }
        }
    }
}
