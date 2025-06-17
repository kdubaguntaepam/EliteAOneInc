using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the response body should contain error message '(.*)'")]
        public void ThenTheResponseBodyShouldContainErrorMessage(string expectedErrorMessage)
        {
            var responseBody = _scenarioContext.Get<string>("ResponseBody");
            var jsonResponse = JObject.Parse(responseBody);
            var actualErrorMessage = jsonResponse["message"].ToString();
            actualErrorMessage.Should().Be(expectedErrorMessage, "Error message should match expected");
        }
    }
}