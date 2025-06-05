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

        [When(@"I retrieve a pet with an invalid ID")]
        public void WhenIRetrieveAPetWithAnInvalidID()
        {
            var invalidPetId = -1; // Assuming -1 is an invalid ID
            _response = _petBusinessLogic.GetPetById(invalidPetId);
        }

        [Then(@"the response status code should be 404")]
        public void ThenTheResponseStatusCodeShouldBe404()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Verified response status code: {StatusCode}", _response.StatusCode);
        }

        [Then(@"the response message should indicate that the pet was not found")]
        public void ThenTheResponseMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified response message: {Content}", _response.Content);
        }
    }
}
