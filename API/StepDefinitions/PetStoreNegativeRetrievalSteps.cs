using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeRetrievalSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";

        public PetStoreNegativeRetrievalSteps(ScenarioContext scenarioContext)
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
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the response error message should indicate 'Pet not found'")]
        public void ThenTheResponseErrorMessageShouldIndicatePetNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified response error message: {_response.Content}");
        }
    }
}