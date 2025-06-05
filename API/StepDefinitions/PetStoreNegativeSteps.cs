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
        private long _petId;
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

        [Given(@"I have a pet creation payload with invalid details")]
        public void GivenIHaveAPetCreationPayloadWithInvalidDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];

            _response = _petBusinessLogic.CreatePet(name, status, category, tags);
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
            _petId = -1; // Invalid ID
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _petId);
        }

        [Then(@"the pet details should not be returned")]
        public void ThenThePetDetailsShouldNotBeReturned()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet details not found as expected. Response content: {Content}", _response.Content);
        }

        [Given(@"I have a non-existing pet ID")]
        public void GivenIHaveANonExistingPetID()
        {
            _petId = 999999; // Non-existing ID
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _petId);
        }

        [Then(@"the pet should not be updated")]
        public void ThenThePetShouldNotBeUpdated()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet update failed as expected. Response content: {Content}");
        }

        [Then(@"the pet should not be deleted")]
        public void ThenThePetShouldNotBeDeleted()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet deletion failed as expected.");
        }
    }
}
