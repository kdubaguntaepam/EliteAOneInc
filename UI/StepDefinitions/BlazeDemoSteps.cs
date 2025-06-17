using TechTalk.SpecFlow;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

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

        [Given(@"I navigate to BlazeDemo home page")]
        public void GivenINavigateToBlazeDemoHomePage()
        {
            var url = ConfigManager.GetConfigValue<string>("BlazeDemoUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be '(.*)'")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle, $"Expected title to be {expectedTitle} but was {actualTitle}");
        }

        [Then(@"the page title should not be '(.*)'")]
        public void ThenThePageTitleShouldNotBe(string incorrectTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().NotBe(incorrectTitle, $"Expected title not to be {incorrectTitle} but it was");
        }
    }
}