using NUnit.Framework;
using TechTalk.SpecFlow;
using EliteAOneInc.API.Clients;
using EliteAOneInc.API.BusinessLogic;
using EliteAOneInc.API.Builders;

namespace EliteAOneInc.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly PetStoreApiClient _apiClient;
        private readonly PetBusinessLogic _businessLogic;
        private readonly ScenarioContext _scenarioContext;

        public PetStoreNegativeSteps(PetStoreApiClient apiClient, PetBusinessLogic businessLogic, ScenarioContext scenarioContext)
        {
            _apiClient = apiClient;
            _businessLogic = businessLogic;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have a pet creation payload with following details")]
        public void GivenIHaveAPetCreationPayloadWithFollowingDetails(Table table)
        {
            var pet = PetBuilder.BuildPetFromTable(table);
            _scenarioContext["PetPayload"] = pet;
        }

        [When(@"I send a POST request to create the pet")]
        public void WhenISendAPostRequestToCreateThePet()
        {
            var pet = _scenarioContext["PetPayload"] as Pet;
            var response = _apiClient.CreatePet(pet);
            _scenarioContext["Response"] = response;
        }

        [Then(@"the response status code should not be 200")]
        public void ThenTheResponseStatusCodeShouldNotBe200()
        {
            var response = _scenarioContext["Response"] as ApiResponse;
            try
            {
                Assert.That(response.StatusCode, Is.Not.EqualTo(200), "Expected status code to not be 200");
            }
            catch (AssertionException ex)
            {
                throw new AssertionException($"Assertion failed: {ex.Message}");
            }
        }

        [Then(@"the pet should not be created")]
        public void ThenThePetShouldNotBeCreated()
        {
            var response = _scenarioContext["Response"] as ApiResponse;
            try
            {
                Assert.That(response.IsSuccessStatusCode, Is.False, "Expected pet creation to fail");
            }
            catch (AssertionException ex)
            {
                throw new AssertionException($"Assertion failed: {ex.Message}");
            }
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["PetID"] = "invalid-id";
        }

        [When(@"I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var petId = _scenarioContext["PetID"] as string;
            var response = _apiClient.GetPetById(petId);
            _scenarioContext["Response"] = response;
        }

        [Then(@"the pet details should not be returned")]
        public void ThenThePetDetailsShouldNotBeReturned()
        {
            var response = _scenarioContext["Response"] as ApiResponse;
            try
            {
                Assert.That(response.IsSuccessStatusCode, Is.False, "Expected pet retrieval to fail");
            }
            catch (AssertionException ex)
            {
                throw new AssertionException($"Assertion failed: {ex.Message}");
            }
        }

        [When(@"I update the pet with generated ID with invalid details")]
        public void WhenIUpdateThePetWithGeneratedIDWithInvalidDetails(Table table)
        {
            var petId = _scenarioContext["PetID"] as string;
            var pet = PetBuilder.BuildPetFromTable(table);
            var response = _apiClient.UpdatePet(petId, pet);
            _scenarioContext["Response"] = response;
        }

        [Then(@"the pet should not be updated")]
        public void ThenThePetShouldNotBeUpdated()
        {
            var response = _scenarioContext["Response"] as ApiResponse;
            try
            {
                Assert.That(response.IsSuccessStatusCode, Is.False, "Expected pet update to fail");
            }
            catch (AssertionException ex)
            {
                throw new AssertionException($"Assertion failed: {ex.Message}");
            }
        }

        [When(@"I delete the pet with generated ID")]
        public void WhenIDeleteThePetWithGeneratedID()
        {
            var petId = _scenarioContext["PetID"] as string;
            var response = _apiClient.DeletePet(petId);
            _scenarioContext["Response"] = response;
        }

        [Then(@"the pet should not be deleted")]
        public void ThenThePetShouldNotBeDeleted()
        {
            var response = _scenarioContext["Response"] as ApiResponse;
            try
            {
                Assert.That(response.IsSuccessStatusCode, Is.False, "Expected pet deletion to fail");
            }
            catch (AssertionException ex)
            {
                throw new AssertionException($"Assertion failed: {ex.Message}");
            }
        }
    }
}
