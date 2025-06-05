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

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When(@"I retrieve the pet by ID '(.*)'")]
        public void WhenIRetrieveThePetByID(string petId)
        {
            _response = _petBusinessLogic.GetPetById(long.Parse(petId));
        }

        [Then(@"the response status code should be 404 for invalid pet ID")]
        public void ThenTheResponseStatusCodeShouldBe404ForInvalidPetID()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound, "Invalid pet ID should return 404 status code");
            Log.Information("Verified response status code: 404 for invalid pet ID");
        }

        [Then(@"the response should contain an error message '(.*)'")]
        public void ThenTheResponseShouldContainAnErrorMessage(string errorMessage)
        {
            _response.Content.Should().Contain(errorMessage, $"Response should contain error message: {errorMessage}");
            Log.Information($"Verified response contains error message: {errorMessage}");
        }
    }
}
