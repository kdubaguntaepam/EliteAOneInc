using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationFramework.Core.Singleton;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class PageTitleSteps
    {
        private readonly IWebDriver _driver;

        public PageTitleSteps()
        {
            _driver = BrowserFactory.GetDriver();
        }

        [Given("I navigate to the BlazeDemo website")]
        public void GivenINavigateToTheBlazeDemoWebsite()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
            Log.Information("Navigated to BlazeDemo website.");
        }

        [Then("the page title should be {string}")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle);
            Log.Information($"Verified page title. Expected: {expectedTitle}, Actual: {actualTitle}");
        }
    }
}
