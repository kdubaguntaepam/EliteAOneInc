using TechTalk.SpecFlow;
using NUnit.Framework;

namespace API.StepDefinitions
{
    [Binding]
    public class NegativePetRetrievalSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiClient _petStoreApiClient;
        private string _invalidPetId;
        private HttpResponseMessage _response;

        public NegativePetRetrievalSteps(ScenarioContext scenarioContext, PetStoreApiClient petStoreApiClient)
        {
            _scenarioContext = scenarioContext;
            _petStoreApiClient = petStoreApiClient;
        }

        [Given(@"I have an invalid pet ID '(.*)'")]
        public void GivenIHaveAnInvalidPetID(string invalidPetId)
        {
            _invalidPetId = invalidPetId;
        }

        [When(@"I retrieve the pet by ID '(.*)'")]
        public async Task WhenIRetrieveThePetByID(string petId)
        {
            _response = await _petStoreApiClient.GetPetByIdAsync(petId);
        }

        [Then(@"I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(HttpStatusCode.NotFound, _response.StatusCode);
        }
    }
}