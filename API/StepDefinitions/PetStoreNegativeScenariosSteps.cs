using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeScenariosSteps
    {
        private readonly PetStoreApiClient _client;
        private IRestResponse _response;
        private string _petId;

        public PetStoreNegativeScenariosSteps(PetStoreApiClient client)
        {
            _client = client;
        }

        [Given("I have a pet ID that does not exist")]
        public void GivenIHaveAPetIDThatDoesNotExist()
        {
            _petId = "999999"; // Assuming this ID does not exist
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _petId = "invalid-id";
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            _response = _client.DeletePet(_petId);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(404, (int)_response.StatusCode);
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            Assert.AreEqual(400, (int)_response.StatusCode);
        }
    }
}