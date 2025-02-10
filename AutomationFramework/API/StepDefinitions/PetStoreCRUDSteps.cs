using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreCRUDSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private long _petId;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";

        public PetStoreCRUDSteps(ScenarioContext scenarioContext)
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

        [Given("I have a pet creation payload with following details")]
        public void GivenIHaveAPetCreationPayloadWithFollowingDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];
            _scenarioContext["PetPayload"] = new { Name = name, Status = status, Category = category, Tags = tags };
        }

        [When("I send a POST request to create the pet")]
        public void WhenISendAPostRequestToCreateThePet()
        {
            var payload = _scenarioContext["PetPayload"];
            _response = _petBusinessLogic.CreatePet(payload);
            _petId = _response.Data.Id;
            _scenarioContext[PetId] = _petId;
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            _response.StatusCode.Should().Be(statusCode);
        }

        [Then("the pet should be created successfully")]
        public void ThenThePetShouldBeCreatedSuccessfully()
        {
            _response.Data.Name.Should().Be(_scenarioContext["PetPayload"].Name);
        }

        [When("I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            _petId = (long)_scenarioContext[PetId];
            _response = _petBusinessLogic.GetPetById(_petId);
        }

        [Then("the pet details should be returned successfully")]
        public void ThenThePetDetailsShouldBeReturnedSuccessfully()
        {
            _response.Data.Id.Should().Be(_petId);
        }

        [When("I update the pet with generated ID with new details")]
        public void WhenIUpdateThePetWithGeneratedIDWithNewDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];
            var payload = new { Id = _petId, Name = name, Status = status, Category = category, Tags = tags };
            _response = _petBusinessLogic.UpdatePet(payload);
        }

        [Then("the pet should be updated successfully")]
        public void ThenThePetShouldBeUpdatedSuccessfully()
        {
            _response.Data.Name.Should().Be(_scenarioContext["PetPayload"].Name);
        }

        [When("I delete the pet with generated ID")]
        public void WhenIDeleteThePetWithGeneratedID()
        {
            _petId = (long)_scenarioContext[PetId];
            _response = _petBusinessLogic.DeletePet(_petId);
        }

        [Then("the pet should be deleted successfully")]
        public void ThenThePetShouldBeDeletedSuccessfully()
        {
            _response.StatusCode.Should().Be(200);
        }
    }
}
