using Example.TestAutomation.ExampleTests.AutomationLibrary;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Example.TestAutomation.ExampleTests.StepDefinitions
{
    [Binding]
    public class CreateVendorAPISteps
    {
        private readonly RestClient _client = RestClientSingleton.Instance;
        private IRestResponse _response;

        [Given("I am logged in to ClaimsPay API as DEFAULT user")]
        public void GivenIAmLoggedInToClaimsPayAPIAsDEFAULTUser()
        {
            var request = new RequestBuilder("heritage_dev/custom/service/v4_1_custom/rest.php", Method.POST)
                .AddParameter("method", "Login")
                .AddParameter("input_type", "JSON")
                .AddParameter("response_type", "JSON")
                .AddParameter("rest_data", "{ \"user_auth\": { \"user_name\": \"heritageuser001\", \"password\": \"e3a409ed06e46cba57264851cfdafa1c\", \"version\": \"1\" } }")
                .Build();
            _response = _client.Execute(request);
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [When("I call CreateVendor method with 'Vendor' with below values")]
        public void WhenICallCreateVendorMethodWithVendorWithBelowValues(Table table)
        {
            var row = table.Rows[0];
            var request = new RequestBuilder("heritage_dev/custom/service/v4_1_custom/rest.php", Method.POST)
                .AddParameter("Business TIN", row["Business TIN"])
                .AddParameter("Business Sub Type", row["Business Sub Type"])
                .Build();
            _response = _client.Execute(request);
        }

        [Then("I should get 'Success' status in CreateVendor response")]
        public void ThenIShouldGetSuccessStatusInCreateVendorResponse()
        {
            Assert.That(_response.Content, Does.Contain("Success"));
        }
    }
}