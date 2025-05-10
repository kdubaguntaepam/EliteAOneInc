@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to validate negative scenarios for pet operations
  So that I can ensure proper error handling

Background:
	Given the PetStore API is available and accessible

@DeletePet @NegativeScenario
Scenario: Delete a pet with an invalid ID
	When I delete the pet with invalid ID
	Then the response status code should be 404
	And an error message should be returned

@DeletePet @NegativeScenario
Scenario: Delete a pet with a non-existent ID
	Given I have a non-existent pet ID
	When I delete the pet with non-existent ID
	Then the response status code should be 404
	And an error message should be returned
