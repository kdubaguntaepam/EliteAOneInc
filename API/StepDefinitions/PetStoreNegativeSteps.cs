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

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When(@"I retrieve the pet by ID '(.*)'")]
        public void WhenIRetrieveThePetByID(long petId)
        {
            _response = _petBusinessLogic.GetPetById(petId);
        }

        [Then(@"the response should contain an error message '(.*)'")]
        public void ThenTheResponseShouldContainAnErrorMessage(string expectedErrorMessage)
        {
            _response.Content.Should().Contain(expectedErrorMessage);
            Log.Information($"Verified error message in response: {expectedErrorMessage}");
        }
    }
}
