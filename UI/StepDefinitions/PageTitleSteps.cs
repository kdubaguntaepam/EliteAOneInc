using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class PageTitleSteps
    {
        private IWebDriver _driver;

        [Given("I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then("the page title should be {string}")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = _driver.Title;
            actualTitle.Should().Be(expectedTitle);
            ScreenshotHelper.CaptureScreenshot(_driver, "PageTitleVerification");
            _driver.Quit();
        }
    }
}
