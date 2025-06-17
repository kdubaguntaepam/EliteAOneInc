using TechTalk.SpecFlow;
using FluentAssertions;
using Serilog;
using System.Net;
using EliteAOneInc.API.Clients;
using EliteAOneInc.Core.Utilities;

namespace EliteAOneInc.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeRetrievalSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiClient _petStoreApiClient;
        private HttpResponseMessage _response;

        public PetStoreNegativeRetrievalSteps(ScenarioContext scenarioContext, PetStoreApiClient petStoreApiClient)
        {
            _scenarioContext = scenarioContext;
            _petStoreApiClient = petStoreApiClient;
        }

        [Given(@"I have the pet ID '(.*)'")]
        public void GivenIHaveThePetID(string petId)
        {
            _scenarioContext["PetId"] = petId;
        }

        [When(@"I retrieve the pet by ID")]
        public async Task WhenIRetrieveThePetByID()
        {
            var petId = _scenarioContext["PetId"].ToString();
            _response = await _petStoreApiClient.GetPetByIdAsync(petId);
            _scenarioContext["Response"] = _response;
        }

        [Then(@"the response status code should be '(.*)'")]
        public void ThenTheResponseStatusCodeShouldBe(string statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);
            _response.StatusCode.Should().Be(expectedStatusCode, because: $"Expected status code to be {expectedStatusCode} but found {_response.StatusCode}");
        }

        [Then(@"the response message should be '(.*)'")]
        public async Task ThenTheResponseMessageShouldBe(string expectedMessage)
        {
            var content = await _response.Content.ReadAsStringAsync();
            content.Should().Contain(expectedMessage, because: $"Expected message to contain '{expectedMessage}' but found '{content}'");
        }
    }
}