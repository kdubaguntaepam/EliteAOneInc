using System;
using System.Net;
using FluentAssertions;
using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;
using AutomationFramework.API.Clients;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiClient _petStoreApiClient;
        private long _invalidPetId;
        private HttpStatusCode _responseStatusCode;
        private string _responseErrorMessage;

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _petStoreApiClient = new PetStoreApiClient();
        }

        [Given("I have an invalid long integer pet ID")]
        public void GivenIHaveAnInvalidLongIntegerPetID()
        {
            _invalidPetId = 9223372036854775807; // Example of a long integer value
            _scenarioContext["InvalidPetId"] = _invalidPetId;
        }

        [When("I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var response = _petStoreApiClient.GetPetById(_invalidPetId);
            _responseStatusCode = response.StatusCode;
            _responseErrorMessage = response.Content;
        }

        [Then("the response status code should be 404")]
        public void ThenTheResponseStatusCodeShouldBe404()
        {
            _responseStatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Then("the response error message should be 'Pet not found'")]
        public void ThenTheResponseErrorMessageShouldBePetNotFound()
        {
            _responseErrorMessage.Should().Contain("Pet not found");
        }
    }
}