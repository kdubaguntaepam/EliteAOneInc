using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;
using AutomationFramework.UI.Pages;
using NUnit.Framework;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoSteps
    {
        private readonly IWebDriver _driver;
        private readonly BlazeDemoPage _blazeDemoPage;

        public BlazeDemoSteps(IWebDriver driver)
        {
            _driver = driver;
            _blazeDemoPage = new BlazeDemoPage(_driver);
        }

        [Given(@"I navigate to BlazeDemo homepage")]
        public void GivenINavigateToBlazeDemoHomepage()
        {
            _blazeDemoPage.NavigateToHomePage();
        }

        [Then(@"the page title should be \"(.*)\"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            string actualTitle = _blazeDemoPage.GetPageTitle();
            Assert.AreEqual(expectedTitle, actualTitle, "The page title is not as expected.");
        }
    }
}
