using NUnit.Framework;
using TechTalk.SpecFlow;
using EliteAOneInc.API.Clients;
using EliteAOneInc.API.BusinessLogic;
using FluentAssertions;

namespace EliteAOneInc.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetBusinessLogic _petBusinessLogic;

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic();
        }

        [Given(@"I have a pet creation payload with following details")]
        public void GivenIHaveAPetCreationPayloadWithFollowingDetails(Table table)
        {
            var petDetails = table.Rows[0];
            var petPayload = new PetBuilder()
                .WithName(petDetails["Name"])
                .WithStatus(petDetails["Status"])
                .WithCategory(petDetails["Category"])
                .WithTags(petDetails["Tags"])
                .Build();
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "PetPayload", petPayload);
        }

        [When(@"I send a POST request to create the pet")]
        public void WhenISendAPOSTRequestToCreateThePet()
        {
            var petPayload = ScenarioContextHelper.Get<dynamic>(_scenarioContext, "PetPayload");
            var response = _petBusinessLogic.CreatePet(petPayload);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "Response", response);
        }

        [Then(@"the response status code should not be 200")]
        public void ThenTheResponseStatusCodeShouldNotBe200()
        {
            var response = ScenarioContextHelper.Get<RestResponse>(_scenarioContext, "Response");
            response.StatusCode.Should().NotBe(200, "the pet creation should fail with invalid data");
        }

        [Then(@"an error message should be returned")]
        public void ThenAnErrorMessageShouldBeReturned()
        {
            var response = ScenarioContextHelper.Get<RestResponse>(_scenarioContext, "Response");
            response.Content.Should().Contain("error", "an error message should be returned for invalid operations");
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "InvalidPetID", "invalid-id");
        }

        [When(@"I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var invalidPetID = ScenarioContextHelper.Get<string>(_scenarioContext, "InvalidPetID");
            var response = _petBusinessLogic.GetPetById(invalidPetID);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "Response", response);
        }

        [When(@"I update the pet with generated ID with new details")]
        public void WhenIUpdateThePetWithGeneratedIDWithNewDetails(Table table)
        {
            var newDetails = table.Rows[0];
            var invalidPetID = ScenarioContextHelper.Get<string>(_scenarioContext, "InvalidPetID");
            var petPayload = new PetBuilder()
                .WithName(newDetails["Name"])
                .WithStatus(newDetails["Status"])
                .WithCategory(newDetails["Category"])
                .WithTags(newDetails["Tags"])
                .Build();
            var response = _petBusinessLogic.UpdatePet(invalidPetID, petPayload);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "Response", response);
        }

        [When(@"I delete the pet with generated ID")]
        public void WhenIDeleteThePetWithGeneratedID()
        {
            var invalidPetID = ScenarioContextHelper.Get<string>(_scenarioContext, "InvalidPetID");
            var response = _petBusinessLogic.DeletePet(invalidPetID);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, "Response", response);
        }
    }
}
