@PetStoreAPI @Regression @APITesting @DeletePet
Feature: Pet Store API Delete Operations - Negative Scenarios
  As an API consumer
  I want to test negative scenarios for delete operations on pets
  So that I can ensure the API handles errors correctly

Background:
	Given the PetStore API is available and accessible

@NegativeScenario
Scenario: Attempt to delete a non-existent pet
	Given I have an invalid pet ID
	When I attempt to delete the pet with the invalid ID
	Then the response status code should be 404
	And the response should indicate that the pet was not found

@NegativeScenario
Scenario: Attempt to delete a pet with invalid API key
	Given I have successfully created a pet with the following details
		| Name  | Status    | Category | Tags |
		| Rocky | available | Dog      | Loyal |
	And I have an invalid API key
	When I attempt to delete the pet with the invalid API key
	Then the response status code should be 401
	And the response should indicate an authentication error