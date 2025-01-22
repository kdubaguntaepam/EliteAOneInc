using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class PageTitleSteps
    {
        private readonly IWebDriver _driver;

        public PageTitleSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be "BlazeDemo"")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            Assert.AreEqual("BlazeDemo", _driver.Title);
        }
    }
}