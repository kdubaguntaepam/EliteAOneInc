using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoPageTitleSteps
    {
        private readonly IWebDriver _driver;
        private readonly BlazeDemoPageTitleBusinessLogic _blazeDemoPageTitleBusinessLogic;

        public BlazeDemoPageTitleSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _blazeDemoPageTitleBusinessLogic = new BlazeDemoPageTitleBusinessLogic(_driver);
        }

        [Given(@"I navigate to BlazeDemo homepage")]
        public void GivenINavigateToBlazeDemoHomepage()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be "(.*)"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _blazeDemoPageTitleBusinessLogic.GetPageTitle();
            actualTitle.Should().Be(expectedTitle, $"Page title should be {expectedTitle}");
        }
    }
}
