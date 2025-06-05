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
        private const string InvalidPetIdKey = "InvalidPetID";

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            long invalidPetId = -1; // Assuming -1 is an invalid ID
            ScenarioContextHelper.SetOrReplace(_scenarioContext, InvalidPetIdKey, invalidPetId);
            Log.Information("Set an invalid pet ID for the test.");
        }

        [When(@"I retrieve the pet by invalid ID")]
        public void WhenIRetrieveThePetByInvalidID()
        {
            var invalidPetId = _scenarioContext.Get<long>(InvalidPetIdKey);
            _response = _petBusinessLogic.GetPetById(invalidPetId);
        }

        [Then(@"the response status code should be 404 for invalid pet ID")]
        public void ThenTheResponseStatusCodeShouldBe404ForInvalidPetID()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Verified response status code: 404 Not Found for invalid pet ID.");
        }

        [Then(@"the error message should indicate pet not found")]
        public void ThenTheErrorMessageShouldIndicatePetNotFound()
        {
            _response.Content.Should().Contain("Pet not found", "The error message should indicate that the pet was not found.");
            Log.Information("Verified error message indicates pet not found.");
        }
    }
}
