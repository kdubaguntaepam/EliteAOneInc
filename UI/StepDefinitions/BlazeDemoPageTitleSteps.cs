using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Core.Base;
using Core.Utilities;

namespace UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoPageTitleSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScreenshotHelper _screenshotHelper;

        public BlazeDemoPageTitleSteps(IWebDriver driver, ScreenshotHelper screenshotHelper)
        {
            _driver = driver;
            _screenshotHelper = screenshotHelper;
        }

        [Given(@"I navigate to the BlazeDemo homepage")]
        public void GivenINavigateToTheBlazeDemoHomepage()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [Then(@"the page title should be "BlazeDemo"")]
        public void ThenThePageTitleShouldBeBlazeDemo()
        {
            string pageTitle = _driver.Title;
            if (pageTitle != "BlazeDemo")
            {
                _screenshotHelper.CaptureScreenshot(_driver, "BlazeDemoPageTitleTest");
                throw new Exception($"Expected page title to be 'BlazeDemo' but was '{pageTitle}'");
            }
        }
    }
}