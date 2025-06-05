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

        [Then(@"the response status code should not be 200")]
        public void ThenTheResponseStatusCodeShouldNotBe200()
        {
            _response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.OK, "Expected failure status code for invalid operation.");
            Log.Information($"Verified response status code is not 200: {_response.StatusCode}");
        }

        [Then(@"an error message should be returned")]
        public void ThenAnErrorMessageShouldBeReturned()
        {
            _response.Content.Should().Contain("error", "The response should contain an error message.");
            Log.Information("Error message returned as expected. Response content: {Content}", _response.Content);
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, -1L); // Using -1 as an invalid ID
        }

        [When(@"I attempt to update the pet with new details")]
        public void WhenIAttemptToUpdateThePetWithNewDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.UpdatePet(petId, name, status, category, tags);
        }

        [When(@"I attempt to delete the pet")]
        public void WhenIAttemptToDeleteThePet()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.DeletePet(petId);
        }
    }
}
