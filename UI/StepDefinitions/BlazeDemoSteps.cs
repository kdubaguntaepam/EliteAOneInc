using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoSteps
    {
        private readonly IWebDriver _driver;
        private readonly BlazeDemoHomePage _blazeDemoHomePage;

        public BlazeDemoSteps(IWebDriver driver)
        {
            _driver = driver;
            _blazeDemoHomePage = new BlazeDemoHomePage(driver);
        }

        [Given(@"I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be "BlazeDemo"")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            string pageTitle = _blazeDemoHomePage.GetPageTitle();
            Assert.That(pageTitle, Is.EqualTo("BlazeDemo"));
        }
    }
}