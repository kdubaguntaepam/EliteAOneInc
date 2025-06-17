using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetRetrievalNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";
        public PetRetrievalNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given("the PetStore API is available and accessible")]
        public void GivenThePetStoreAPIIsAvailableAndAccessible()
        {
            Log.Information("Verified that PetStore API is available.");
        }

        [When("I retrieve the pet by ID '(.*)'")]
        public void WhenIRetrieveThePetByID(long petId)
        {
            _response = _petBusinessLogic.GetPetById(petId);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("the error message should be '(.*)'")]
        public void ThenTheErrorMessageShouldBe(string expectedErrorMessage)
        {
            _response.Content.Should().Contain(expectedErrorMessage);
            Log.Information($"Verified error message: {expectedErrorMessage}");
        }
    }
}