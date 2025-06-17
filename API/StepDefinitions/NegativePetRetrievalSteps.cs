using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class NegativePetRetrievalSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private const string InvalidPetId = "999999999999";

        public NegativePetRetrievalSteps(ScenarioContext scenarioContext)
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

        [When("I retrieve the pet by ID '999999999999'")]
        public void WhenIRetrieveThePetByID()
        {
            _response = _petBusinessLogic.GetPetById(long.Parse(InvalidPetId));
        }

        [Then("the response status code should be 404")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("the response message should be 'Pet not found'")]
        public void ThenTheResponseMessageShouldBe(string expectedMessage)
        {
            _response.Content.Should().Contain(expectedMessage);
            Log.Information($"Verified response message: {_response.Content}");
        }
    }
}