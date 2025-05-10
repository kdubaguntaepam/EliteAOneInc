@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Delete Operations
  As an API consumer
  I want to ensure proper error handling for delete operations
  So that I can manage pet information efficiently

Background:
	Given the PetStore API is available and accessible

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID
	When I delete the pet with ID "invalid-id"
	Then the response status code should be 404
	And the response message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet without providing an ID
	When I send a DELETE request to the pet deletion endpoint without an ID
	Then the response status code should be 405
	And the response message should indicate that the method is not allowed