using BoDi;
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
        private string InvalidPetId = "InvalidPetID";

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, InvalidPetId, -1);
            Log.Information("Set an invalid pet ID for testing.");
        }

        [Then(@"the error message should indicate that the pet was not found")]
        public void ThenTheErrorMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found", "The error message should indicate that the pet was not found.");
            Log.Information("Verified error message: Pet not found.");
        }
    }
}
