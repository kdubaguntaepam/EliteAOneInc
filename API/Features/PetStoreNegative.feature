@PetStoreAPI @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to ensure the Pet Store API handles invalid scenarios gracefully
  So that I can verify the robustness of the API

Background:
	Given the PetStore API is available and accessible

@RetrievePet @NegativeScenario
Scenario: Retrieve a pet with invalid ID
	When I retrieve a pet with an invalid ID
	Then the response status code should be 404
	And the response message should indicate that the pet was not found
