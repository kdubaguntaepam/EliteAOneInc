using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using AutomationFramework.Core.Config;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class PageTitleSteps
    {
        private readonly IWebDriver _driver;

        public PageTitleSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
        }

        [Given(@"I navigate to BlazeDemo homepage")]
        public void GivenINavigateToBlazeDemoHomepage()
        {
            var url = ConfigManager.GetConfigValue<string>("BlazeDemoUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle, $"Expected page title to be {expectedTitle} but was {actualTitle}");
        }
    }
}
