using TechTalk.SpecFlow;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class BlazeDemoSteps
    {
        private readonly IWebDriver _driver;

        public BlazeDemoSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
        }

        [Given(@"I navigate to 'https://blazedemo.com/'")]
        public void GivenINavigateToBlazeDemo()
        {
            _driver.Navigate().GoToUrl("https://blazedemo.com/");
        }

        [When(@"I select 'departure city' as '(.*)' and 'destination city' as '(.*)'")]
        public void WhenISelectDepartureAndDestinationCity(string departureCity, string destinationCity)
        {
            var departureDropdown = _driver.FindElement(By.Name("fromPort"));
            var destinationDropdown = _driver.FindElement(By.Name("toPort"));

            var selectDeparture = new SelectElement(departureDropdown);
            var selectDestination = new SelectElement(destinationDropdown);

            selectDeparture.SelectByText(departureCity);
            selectDestination.SelectByText(destinationCity);
        }

        [When(@"I click on 'Find Flights' button")]
        public void WhenIClickOnFindFlightsButton()
        {
            var findFlightsButton = _driver.FindElement(By.CssSelector("input[type='submit']"));
            findFlightsButton.Click();
        }

        [Then(@"I should see the list of available flights")]
        public void ThenIShouldSeeTheListOfAvailableFlights()
        {
            var flightsTable = _driver.FindElement(By.CssSelector("table.table"));
            flightsTable.Displayed.Should().BeTrue("The list of available flights should be displayed.");
        }

        [Then(@"I should see an error message indicating no flights are available")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            var errorMessage = _driver.FindElement(By.CssSelector("div.alert.alert-danger"));
            errorMessage.Displayed.Should().BeTrue("An error message indicating no flights are available should be displayed.");
        }
    }
}
