using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
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

        [Given(@"I navigate to 'https://blazedemo.com/'")]
        public void GivenINavigateToBlazeDemo()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be 'BlazeDemo'")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            _driver.Title.Should().Be("BlazeDemo", "Page title should be BlazeDemo");
        }
    }
}