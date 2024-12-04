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

        [Given(@"I navigate to \"(.*)\"")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Log.Information($"Navigated to URL: {url}");
        }

        [Then(@"the page title should be \"(.*)\"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle);
            Log.Information($"Verified page title. Expected: {expectedTitle}, Actual: {actualTitle}");
        }
    }
}
