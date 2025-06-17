using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

[Binding]
public class BlazeDemoSteps
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public BlazeDemoSteps(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Given(@"I am on the BlazeDemo homepage")]
    public void GivenIAmOnTheBlazeDemoHomepage()
    {
        _driver.Navigate().GoToUrl("https://blazedemo.com/");
    }

    [When(@"I select departure city as "(.*)" and destination city as "(.*)"")]
    public void WhenISelectDepartureCityAsAndDestinationCityAs(string departureCity, string destinationCity)
    {
        var departureDropdown = _wait.Until(ExpectedConditions.ElementIsVisible(By.Name("fromPort")));
        var destinationDropdown = _wait.Until(ExpectedConditions.ElementIsVisible(By.Name("toPort")));
        var selectDeparture = new SelectElement(departureDropdown);
        var selectDestination = new SelectElement(destinationDropdown);
        selectDeparture.SelectByText(departureCity);
        selectDestination.SelectByText(destinationCity);
    }

    [When(@"I click on "Find Flights"")]
    public void WhenIClickOnFindFlights()
    {
        var findFlightsButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='submit']")));
        findFlightsButton.Click();
    }

    [Then(@"I should see a list of available flights")]
    public void ThenIShouldSeeAListOfAvailableFlights()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("table.table")));
    }

    [When(@"I choose the first flight")]
    public void WhenIChooseTheFirstFlight()
    {
        var firstFlightButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("table.table tr:nth-child(2) input")));
        firstFlightButton.Click();
    }

    [When(@"I enter my details and purchase the flight")]
    public void WhenIEnterMyDetailsAndPurchaseTheFlight()
    {
        var nameField = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("inputName")));
        var addressField = _driver.FindElement(By.Id("address"));
        var cityField = _driver.FindElement(By.Id("city"));
        var stateField = _driver.FindElement(By.Id("state"));
        var zipCodeField = _driver.FindElement(By.Id("zipCode"));
        var cardTypeDropdown = _driver.FindElement(By.Id("cardType"));
        var creditCardNumberField = _driver.FindElement(By.Id("creditCardNumber"));
        var creditCardMonthField = _driver.FindElement(By.Id("creditCardMonth"));
        var creditCardYearField = _driver.FindElement(By.Id("creditCardYear"));
        var nameOnCardField = _driver.FindElement(By.Id("nameOnCard"));
        var rememberMeCheckbox = _driver.FindElement(By.Id("rememberMe"));
        var purchaseFlightButton = _driver.FindElement(By.CssSelector("input[type='submit']"));

        nameField.SendKeys("John Doe");
        addressField.SendKeys("123 Main St");
        cityField.SendKeys("Anytown");
        stateField.SendKeys("CA");
        zipCodeField.SendKeys("12345");
        new SelectElement(cardTypeDropdown).SelectByText("Visa");
        creditCardNumberField.SendKeys("4111111111111111");
        creditCardMonthField.SendKeys("12");
        creditCardYearField.SendKeys("2023");
        nameOnCardField.SendKeys("John Doe");
        rememberMeCheckbox.Click();
        purchaseFlightButton.Click();
    }

    [Then(@"I should see a confirmation message with the booking details")]
    public void ThenIShouldSeeAConfirmationMessageWithTheBookingDetails()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.container h1")));
    }

    [When(@"I leave the details form empty and purchase the flight")]
    public void WhenILeaveTheDetailsFormEmptyAndPurchaseTheFlight()
    {
        var purchaseFlightButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='submit']")));
        purchaseFlightButton.Click();
    }

    [Then(@"I should see an error message indicating missing details")]
    public void ThenIShouldSeeAnErrorMessageIndicatingMissingDetails()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.alert.alert-danger")));
    }
}