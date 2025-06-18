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

        [Given(@"I navigate to '(.*)'")]
        public void GivenINavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be '(.*)'")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle, $"Expected page title to be '{expectedTitle}' but was '{actualTitle}'");
        }
    }
}