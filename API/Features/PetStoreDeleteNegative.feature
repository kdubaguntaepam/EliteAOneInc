@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Delete Operations
  As an API consumer
  I want to handle errors when deleting pets
  So that I can ensure robust error handling

Background:
	Given the PetStore API is available and accessible

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID
	Given I have an invalid pet ID
	When I send a DELETE request to delete the pet
	Then the response status code should be 404
	And an error message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet without providing an ID
	Given I do not provide a pet ID
	When I send a DELETE request to delete the pet
	Then the response status code should be 400
	And an error message should indicate that the pet ID is required