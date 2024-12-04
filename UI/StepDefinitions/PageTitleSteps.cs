using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using AutomationFramework.Core.Config;
using Serilog;

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

        [Given(@"I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            var url = ConfigManager.GetConfigValue<string>("BlazeDemoUrl");
            _driver.Navigate().GoToUrl(url);
            Log.Information("Navigated to BlazeDemo homepage.");
        }

        [Then(@"the page title should be \"(.*)\"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle, $"Page title should be {expectedTitle} but was {actualTitle}");
            Log.Information($"Verified page title: {actualTitle}");
        }
    }
}
