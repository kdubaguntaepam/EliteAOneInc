using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreDeleteNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;

        public PetStoreDeleteNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When(@"I delete the pet with ID "invalid-id"")]
        public void WhenIDeleteThePetWithInvalidID()
        {
            _response = _petBusinessLogic.DeletePet("invalid-id");
        }

        [When(@"I send a DELETE request to the pet deletion endpoint without an ID")]
        public void WhenISendADeleteRequestWithoutID()
        {
            _response = _petBusinessLogic.DeletePetWithoutId(); // Assuming this method exists in PetBusinessLogic
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the response message should indicate that the pet was not found")]
        public void ThenTheResponseMessageShouldIndicatePetNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified response message indicates pet not found.");
        }

        [Then(@"the response message should indicate that the method is not allowed")]
        public void ThenTheResponseMessageShouldIndicateMethodNotAllowed()
        {
            _response.Content.Should().Contain("Method not allowed");
            Log.Information("Verified response message indicates method not allowed.");
        }
    }
}
