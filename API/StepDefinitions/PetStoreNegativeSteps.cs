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
        private string PetId = "PetID";
        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When("I delete the pet with invalid ID")]
        public void WhenIDeleteThePetWithInvalidID()
        {
            _response = _petBusinessLogic.DeletePet(-1); // Assuming -1 is an invalid ID
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then("an appropriate error message should be returned")]
        public void ThenAnAppropriateErrorMessageShouldBeReturned()
        {
            _response.Content.Should().Contain("Pet not found"); // Assuming the error message contains this text
            Log.Information($"Verified error message: {_response.Content}");
        }

        [Given("I have a non-existent pet ID")]
        public void GivenIHaveANonExistentPetID()
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, 999999); // Assuming 999999 is a non-existent ID
        }

        [When("I delete the pet with non-existent ID")]
        public void WhenIDeleteThePetWithNonExistentID()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.DeletePet(petId);
        }
    }
}
