using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace EliteAOneInc.StepDefinitions
{
    [Binding]
    public class PetStoreStatusCodesSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;

        public PetStoreStatusCodesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _httpClient = new HttpClient();
        }

        [Given(@"I have a pet with ID '(.*)' and name '(.*)'")]
        public void GivenIHaveAPetWithIDAndName(string petId, string petName)
        {
            var pet = new { id = petId, name = petName };
            _scenarioContext.Set(pet, "Pet");
        }

        [When(@"I create the pet")]
        public async Task WhenICreateThePet()
        {
            var pet = _scenarioContext.Get<object>("Pet");
            var content = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync("https://petstore.swagger.io/v2/pet", content);
        }

        [Then(@"the response status code should be '(.*)'")]
        public void ThenTheResponseStatusCodeShouldBe(string expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, ((int)_response.StatusCode).ToString());
        }

        [Given(@"I have a pet with ID '(.*)'")]
        public void GivenIHaveAPetWithID(string petId)
        {
            _scenarioContext.Set(petId, "PetId");
        }

        [Given(@"I have an invalid pet ID '(.*)'")]
        public void GivenIHaveAnInvalidPetID(string invalidPetId)
        {
            _scenarioContext.Set(invalidPetId, "InvalidPetId");
        }

        [When(@"I retrieve the pet by ID '(.*)'")]
        public async Task WhenIRetrieveThePetByID(string petId)
        {
            _response = await _httpClient.GetAsync($"https://petstore.swagger.io/v2/pet/{petId}");
        }

        [When(@"I update the pet with new name '(.*)'")]
        public async Task WhenIUpdateThePetWithNewName(string newName)
        {
            var petId = _scenarioContext.Get<string>("PetId");
            var pet = new { id = petId, name = newName };
            var content = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8, "application/json");
            _response = await _httpClient.PutAsync("https://petstore.swagger.io/v2/pet", content);
        }

        [When(@"I delete the pet by ID '(.*)'")]
        public async Task WhenIDeleteThePetByID(string petId)
        {
            _response = await _httpClient.DeleteAsync($"https://petstore.swagger.io/v2/pet/{petId}");
        }
    }
}
