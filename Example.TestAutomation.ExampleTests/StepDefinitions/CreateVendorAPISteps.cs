using Example.TestAutomation.ExampleTests.AutomationLibrary;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Example.TestAutomation.ExampleTests.StepDefinitions
{
    [Binding]
    public class CreateVendorAPISteps
    {
        private readonly ScenarioContext _context;
        private IRestResponse _response;

        public CreateVendorAPISteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given("I am logged in to ClaimsPay API as DEFAULT user")]
        public void GivenIAmLoggedInToClaimsPayAPIAsDEFAULTUser()
        {
            // Login logic here
        }

        [When("I call CreateVendor method with 'Vendor' with below values")]
        public void WhenICallCreateVendorMethodWithVendorWithBelowValues(Table table)
        {
            // CreateVendor logic here
        }

        [Then("I should get 'Success' status in CreateVendor response")]
        public void ThenIShouldGetSuccessStatusInCreateVendorResponse()
        {
            // Assert success status here
        }
    }
}