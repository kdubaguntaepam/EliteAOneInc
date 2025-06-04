using AutomationFramework.API.BusinessLogic;
using AutomationFramework.API.Clients;
using AutomationFramework.Core.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreDeleteNegativeSteps
    {
        private readonly PetStoreApiClient _petStoreApiClient;
        private readonly PetBusinessLogic _petBusinessLogic;
        private readonly ScenarioContext _scenarioContext;

        public PetStoreDeleteNegativeSteps(PetStoreApiClient petStoreApiClient, PetBusinessLogic petBusinessLogic, ScenarioContext scenarioContext)
        {
            _petStoreApiClient = petStoreApiClient;
            _petBusinessLogic = petBusinessLogic;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetId()
        {
            _scenarioContext["InvalidPetId"] = -1; // Using a negative ID as an invalid ID
        }

        [When(@"I attempt to delete the pet with the invalid ID")]
        public async Task WhenIAttemptToDeleteThePetWithTheInvalidId()
        {
            var invalidPetId = (int)_scenarioContext["InvalidPetId"];
            var response = await _petStoreApiClient.DeletePetAsync(invalidPetId);
            _scenarioContext["ApiResponse"] = response;
        }

        [Given(@"I have an invalid API key")]
        public void GivenIHaveAnInvalidApiKey()
        {
            _petStoreApiClient.SetInvalidApiKey();
        }

        [When(@"I attempt to delete the pet with the invalid API key")]
        public async Task WhenIAttemptToDeleteThePetWithTheInvalidApiKey()
        {
            var petId = (int)_scenarioContext["PetId"];
            var response = await _petStoreApiClient.DeletePetAsync(petId);
            _scenarioContext["ApiResponse"] = response;
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            var response = (RestSharp.RestResponse)_scenarioContext["ApiResponse"];
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }

        [Then(@"the response should indicate that the pet was not found")]
        public void ThenTheResponseShouldIndicateThatThePetWasNotFound()
        {
            var response = (RestSharp.RestResponse)_scenarioContext["ApiResponse"];
            Assert.IsTrue(response.Content.Contains("Pet not found"));
        }

        [Then(@"the response should indicate an authentication error")]
        public void ThenTheResponseShouldIndicateAnAuthenticationError()
        {
            var response = (RestSharp.RestResponse)_scenarioContext["ApiResponse"];
            Assert.IsTrue(response.Content.Contains("Invalid API key"));
        }
    }
}