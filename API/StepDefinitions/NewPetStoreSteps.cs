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
    public class NewPetStoreSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private long _petId;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";
        public NewPetStoreSteps(ScenarioContext scenarioContext)
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

        [When("I attempt to delete a pet with an invalid ID")]
        public void WhenIAttemptToDeleteAPetWithAnInvalidID()
        {
            var invalidPetId = -1; // Invalid ID
            _response = _petBusinessLogic.DeletePet(invalidPetId);
        }

        [When("I attempt to delete the pet with the non-existent ID")]
        public void WhenIAttemptToDeleteThePetWithTheNonExistentID()
        {
            var nonExistentPetId = 999999; // Assuming this ID does not exist
            _response = _petBusinessLogic.DeletePet(nonExistentPetId);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("the error message should indicate that the pet was not found")]
        public void ThenTheErrorMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified error message: Pet not found");
        }
    }
}
