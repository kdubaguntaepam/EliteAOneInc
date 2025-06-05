@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Operations
  As an API consumer
  I want to test failure cases for CRUD operations on pets
  So that I can ensure the API handles errors gracefully

Background:
	Given the PetStore API is available and accessible

@CreatePet @NegativeScenario
Scenario Outline: Fail to create a new pet with invalid data
	Given I have a pet creation payload with invalid details
		| Name      | Status      | Category | Tags      |
		| <PetName> | <PetStatus> | <Breed>  | <PetTags> |
	When I send a POST request to create the pet
	Then the response status code should not be 200
	And an error message should be returned

Examples:
	| PetName  | PetStatus | Breed | PetTags  |
	|          | available | Dog   | Friendly |
	| Whiskers | invalid   | Cat   | Playful  |
	| Rex      | sold      |       | Guardian |

@RetrievePet @NegativeScenario
Scenario: Fail to retrieve a pet by invalid ID
	Given I have an invalid pet ID
	When I retrieve the pet by ID
	Then the response status code should not be 200
	And an error message should be returned

@UpdatePet @NegativeScenario
Scenario Outline: Fail to update a non-existing pet
	Given I have a non-existing pet ID
	When I attempt to update the pet with new details
		| Name      | Status      | Category | Tags   |
		| <NewName> | <NewStatus> | <Breed>  | <Tags> |
	Then the response status code should not be 200
	And an error message should be returned

Examples:
	| NewName  | NewStatus | Breed | Tags    | PetID |
	| Maximus  | sold      | Dog   | Guard   | 9999  |
	| Princess | available | Cat   | Playful | 8888  |

@DeletePet @NegativeScenario
Scenario: Fail to delete a pet by invalid ID
	Given I have an invalid pet ID
	When I attempt to delete the pet
	Then the response status code should not be 200
	And an error message should be returned
