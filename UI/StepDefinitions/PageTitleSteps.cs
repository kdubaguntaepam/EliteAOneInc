using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class PageTitleSteps
    {
        private IWebDriver _driver;

        public PageTitleSteps()
        {
            _driver = new ChromeDriver();
        }

        [Given("I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
            Log.Information("Navigated to BlazeDemo homepage.");
        }

        [Then("the page title should be {string}")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle);
            Log.Information($"Verified page title: {actualTitle}");
            _driver.Quit();
        }
    }
}
