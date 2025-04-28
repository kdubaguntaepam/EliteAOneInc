@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to handle errors gracefully
  So that I can ensure robustness of the API

Background:
	Given the PetStore API is available and accessible

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID
	When I attempt to delete a pet with ID "invalid-id"
	Then the response status code should be 404
	And the response message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with a non-existent ID
	When I attempt to delete a pet with ID "999999"
	Then the response status code should be 404
	And the response message should indicate that the pet was not found
