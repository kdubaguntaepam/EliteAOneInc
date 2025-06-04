using AutomationFramework.Core.Base;
using AutomationFramework.Core.Singleton;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class BlazedemoPageTitleSteps : BasePage
    {
        private readonly IWebDriver _driver;

        public BlazedemoPageTitleSteps(BrowserFactory browserFactory)
        {
            _driver = browserFactory.Driver;
        }

        [Given(@"I navigate to the Blazedemo website")]
        public void GivenINavigateToTheBlazedemoWebsite()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, _driver.Title, "Page title does not match the expected value.");
        }
    }
}