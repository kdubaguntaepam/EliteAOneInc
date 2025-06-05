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
        private long _invalidPetId = -1; // Invalid pet ID for negative scenarios
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"the PetStore API is available and accessible")]
        public void GivenThePetStoreAPIIsAvailableAndAccessible()
        {
            Log.Information("Verified that PetStore API is available.");
        }

        [Given(@"I have a pet creation payload with following invalid details")]
        public void GivenIHaveAPetCreationPayloadWithFollowingInvalidDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];

            _response = _petBusinessLogic.CreatePet(name, status, category, tags);
        }

        [When(@"I send a POST request to create the pet")]
        public void WhenISendAPostRequestToCreateThePet()
        {
            _response.Should().NotBeNull("Response from Create Pet API should not be null");
            Log.Information("POST request sent to create a pet with provided payload.");
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the pet should not be created")]
        public void ThenThePetShouldNotBeCreated()
        {
            _response.Content.Should().NotContain("\"id\":", "The response should not contain the 'id' of the created pet.");
            Log.Information($"Pet creation failed as expected. Response content: {_response.Content}");
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _invalidPetId);
        }

        [When(@"I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.GetPetById(petId);
        }

        [Then(@"the pet details should not be returned")]
        public void ThenThePetDetailsShouldNotBeReturned()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet details retrieval failed as expected. Response content: {Content}", _response.Content);
        }

        [When(@"I update the pet with invalid ID with new details")]
        public void WhenIUpdateThePetWithInvalidIDWithNewDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.UpdatePet(petId, name, status, category, tags);
        }

        [Then(@"the pet should not be updated")]
        public void ThenThePetShouldNotBeUpdated()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet update failed as expected. Response content: {Content}");
        }

        [When(@"I delete the pet with invalid ID")]
        public void WhenIDeleteThePetWithInvalidID()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then(@"the pet should not be deleted")]
        public void ThenThePetShouldNotBeDeleted()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet deletion failed as expected.");
        }
    }
}
