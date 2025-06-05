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

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _petId = -1; // Invalid ID
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _petId);
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

        [Then(@"the pet should not be created")]
        public void ThenThePetShouldNotBeCreated()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            Log.Information("Pet creation failed as expected. Response content: {Content}", _response.Content);
        }

        [Then(@"the pet details should not be returned")]
        public void ThenThePetDetailsShouldNotBeReturned()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet retrieval failed as expected. Response content: {Content}", _response.Content);
        }

        [Then(@"the pet should not be updated")]
        public void ThenThePetShouldNotBeUpdated()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet update failed as expected. Response content: {Content}", _response.Content);
        }

        [Then(@"the pet should not be deleted")]
        public void ThenThePetShouldNotBeDeleted()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Pet deletion failed as expected. Response content: {Content}", _response.Content);
        }
    }
}
