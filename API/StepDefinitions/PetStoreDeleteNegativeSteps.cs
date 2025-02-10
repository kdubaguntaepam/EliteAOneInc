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

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["PetId"] = -1; // Invalid ID
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["PetId"] = null; // No ID
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            var petId = _scenarioContext.ContainsKey("PetId") ? _scenarioContext["PetId"] : null;
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("the response message should indicate that the pet was not found")]
        public void ThenTheResponseMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified response message indicates pet not found.");
        }

        [Then("the response message should indicate a bad request")]
        public void ThenTheResponseMessageShouldIndicateABadRequest()
        {
            _response.Content.Should().Contain("Bad request");
            Log.Information("Verified response message indicates bad request.");
        }
    }
}
