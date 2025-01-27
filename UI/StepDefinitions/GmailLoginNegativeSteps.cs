using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginNegativeSteps
    {
        private readonly IWebDriver _driver;
        private readonly GmailLoginBusinessLogic _gmailLoginBusinessLogic;

        public GmailLoginNegativeSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _gmailLoginBusinessLogic = new GmailLoginBusinessLogic(_driver);
        }

        [Given(@"I navigate to Gmail login page")]
        public void GivenINavigateToGmailLoginPage()
        {
            var url = ConfigManager.GetConfigValue<string>("GmailLoginUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"I enter invalid "(.*)" and "(.*)"")]
        public void WhenIEnterInvalidCredentials(string email, string password)
        {
            _gmailLoginBusinessLogic.Login(email, password);
        }

        [Then(@"I should see an error message for invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageForInvalidCredentials()
        {
            _gmailLoginBusinessLogic.VerifyErrorMessageVisible().Should().BeTrue("Error message should be displayed for invalid credentials.");
        }
    }
}
