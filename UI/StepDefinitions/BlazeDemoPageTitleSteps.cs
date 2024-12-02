using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoPageTitleSteps
    {
        private readonly IWebDriver _driver;
        private readonly BlazeDemoPage _blazeDemoPage;

        public BlazeDemoPageTitleSteps(IWebDriver driver)
        {
            _driver = driver;
            _blazeDemoPage = new BlazeDemoPage(_driver);
        }

        [Given("I navigate to the BlazeDemo website")]
        public void GivenINavigateToTheBlazeDemoWebsite()
        {
            _blazeDemoPage.NavigateToBlazeDemo();
        }

        [Then("the page title should be \"BlazeDemo\"")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            Assert.AreEqual("BlazeDemo", _driver.Title);
        }
    }
}