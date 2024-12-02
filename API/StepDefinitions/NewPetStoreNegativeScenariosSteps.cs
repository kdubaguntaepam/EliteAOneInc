using TechTalk.SpecFlow;
using NUnit.Framework;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class NewPetStoreNegativeScenariosSteps
    {
        private readonly PetStoreApiClient _petStoreApiClient;
        private string _invalidPetId;
        private string _response;

        public NewPetStoreNegativeScenariosSteps(PetStoreApiClient petStoreApiClient)
        {
            _petStoreApiClient = petStoreApiClient;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _invalidPetId = "invalid-id";
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _invalidPetId = string.Empty;
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            _response = _petStoreApiClient.DeletePet(_invalidPetId);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual("404", _response);
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            Assert.AreEqual("400", _response);
        }
    }
}