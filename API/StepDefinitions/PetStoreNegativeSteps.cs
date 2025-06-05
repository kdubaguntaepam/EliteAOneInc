using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private const string PetId = "PetID";

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I set an invalid pet ID '(.*)'")]
        public void GivenISetAnInvalidPetID(long invalidPetId)
        {
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, invalidPetId);
        }
    }
}
