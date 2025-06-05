using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";
        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When(@"I retrieve the pet by ID 'invalidID'")]
        public void WhenIRetrieveThePetByIDInvalidID()
        {
            _response = _petBusinessLogic.GetPetById(-1); // Assuming -1 is an invalid ID
        }

        [Then(@"the response status code should be 404 for invalid ID")]
        public void ThenTheResponseStatusCodeShouldBe404ForInvalidID()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound, "Expected status code to be 404 for invalid ID");
            Log.Information("Verified response status code: {StatusCode}", _response.StatusCode);
        }

        [Then(@"the response should contain an error message 'Pet not found'")]
        public void ThenTheResponseShouldContainAnErrorMessagePetNotFound()
        {
            _response.Content.Should().Contain("Pet not found", "Expected error message to be 'Pet not found'");
            Log.Information("Verified error message in response: {Content}", _response.Content);
        }
    }
}