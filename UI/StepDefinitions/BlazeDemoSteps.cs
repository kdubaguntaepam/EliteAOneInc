using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using AutomationFramework.Core.Config;

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

        [Given(@"I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            var url = "https://blazedemo.com/";
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be 'BlazeDemo'")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            var expectedTitle = "BlazeDemo";
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle, because: "the page title should match the expected title.");
        }
    }
}