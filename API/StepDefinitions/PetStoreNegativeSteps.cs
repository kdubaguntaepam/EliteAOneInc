using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Serilog;
using EliteAOneInc.API.Clients;
using EliteAOneInc.API.BusinessLogic;
using EliteAOneInc.Core.Utilities;

namespace EliteAOneInc.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiClient _apiClient;
        private readonly PetBusinessLogic _petBusinessLogic;

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _apiClient = new PetStoreApiClient();
            _petBusinessLogic = new PetBusinessLogic();
        }

        [Given(@"I have a pet creation payload with invalid details")]
        public void GivenIHaveAPetCreationPayloadWithInvalidDetails(Table table)
        {
            var petPayload = _petBusinessLogic.BuildInvalidPetPayload(table);
            _scenarioContext.Set(petPayload, "PetPayload");
        }

        [When(@"I send a POST request to create the pet")]
        public void WhenISendAPostRequestToCreateThePet()
        {
            var petPayload = _scenarioContext.Get<object>("PetPayload");
            var response = _apiClient.CreatePet(petPayload);
            _scenarioContext.Set(response, "Response");
        }

        [Then(@"the response status code should be 400")]
        public void ThenTheResponseStatusCodeShouldBe400()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest, "Invalid pet creation payload should return 400 status code");
        }

        [Then(@"the pet should not be created")]
        public void ThenThePetShouldNotBeCreated()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.Content.ReadAsStringAsync().Result.Should().Contain("error", "Invalid pet creation payload should not create a pet");
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext.Set(-1, "PetID");
        }

        [When(@"I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var petID = _scenarioContext.Get<int>("PetID");
            var response = _apiClient.GetPetById(petID);
            _scenarioContext.Set(response, "Response");
        }

        [Then(@"the response status code should be 404")]
        public void ThenTheResponseStatusCodeShouldBe404()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound, "Invalid pet ID should return 404 status code");
        }

        [Then(@"the pet details should not be returned")]
        public void ThenThePetDetailsShouldNotBeReturned()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.Content.ReadAsStringAsync().Result.Should().Contain("error", "Invalid pet ID should not return pet details");
        }

        [When(@"I update the pet with generated ID with invalid details")]
        public void WhenIUpdateThePetWithGeneratedIDWithInvalidDetails(Table table)
        {
            var petID = _scenarioContext.Get<int>("PetID");
            var petPayload = _petBusinessLogic.BuildInvalidPetPayload(table);
            var response = _apiClient.UpdatePet(petID, petPayload);
            _scenarioContext.Set(response, "Response");
        }

        [Then(@"the pet should not be updated")]
        public void ThenThePetShouldNotBeUpdated()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.Content.ReadAsStringAsync().Result.Should().Contain("error", "Invalid pet update payload should not update the pet");
        }

        [When(@"I delete the pet with generated ID")]
        public void WhenIDeleteThePetWithGeneratedID()
        {
            var petID = _scenarioContext.Get<int>("PetID");
            var response = _apiClient.DeletePet(petID);
            _scenarioContext.Set(response, "Response");
        }

        [Then(@"the pet should not be deleted")]
        public void ThenThePetShouldNotBeDeleted()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("Response");
            response.Content.ReadAsStringAsync().Result.Should().Contain("error", "Invalid pet ID should not delete the pet");
        }
    }
}
