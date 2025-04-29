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
            _scenarioContext["PetID"] = -1; // Invalid ID
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["PetID"] = null; // No ID provided
        }

        [When("I send a DELETE request to delete the pet")]
        public void WhenISendADELETERequestToDeleteThePet()
        {
            var petId = _scenarioContext.ContainsKey("PetID") ? _scenarioContext["PetID"] : null;
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("an error message should indicate that the pet was not found")]
        public void ThenAnErrorMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified error message for pet not found.");
        }

        [Then("an error message should indicate that the pet ID is required")]
        public void ThenAnErrorMessageShouldIndicateThatThePetIDIsRequired()
        {
            _response.Content.Should().Contain("Pet ID is required");
            Log.Information("Verified error message for missing pet ID.");
        }
    }
}