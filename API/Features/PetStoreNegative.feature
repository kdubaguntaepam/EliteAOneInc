@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Operations
  As an API consumer
  I want to handle errors gracefully when performing CRUD operations on pets
  So that I can ensure the system behaves correctly under invalid conditions

Background:
  Given the PetStore API is available and accessible

@CreatePet @NegativeScenario
Scenario Outline: Fail to create a new pet with invalid data
  Given I have a pet creation payload with following details
    | Name      | Status      | Category | Tags      |
    | <PetName> | <PetStatus> | <Breed>  | <PetTags> |
  When I send a POST request to create the pet
  Then the response status code should not be 200
  And the pet should not be created

Examples:
  | PetName  | PetStatus | Breed | PetTags  |
  |          | available | Dog   | Friendly |  # Missing PetName
  | Whiskers |           | Cat   | Playful  |  # Missing PetStatus
  | Rex      | sold      |       | Guardian |  # Missing Breed

@RetrievePet @NegativeScenario
Scenario: Fail to retrieve a pet by invalid ID
  Given I have an invalid pet ID
  When I retrieve the pet by ID
  Then the response status code should be 404
  And the pet details should not be returned

@UpdatePet @NegativeScenario
Scenario Outline: Fail to update a non-existent pet
  Given I have a non-existent pet ID
  When I update the pet with generated ID with new details
    | Name      | Status      | Category | Tags   |
    | <NewName> | <NewStatus> | <Breed>  | <Tags> |
  Then the response status code should be 404
  And the pet should not be updated

Examples:
  | NewName  | NewStatus | Breed | Tags    |
  | Maximus  | sold      | Dog   | Guard   |
  | Princess | available | Cat   | Playful |

@DeletePet @NegativeScenario
Scenario: Fail to delete a pet by invalid ID
  Given I have an invalid pet ID
  When I delete the pet with generated ID
  Then the response status code should be 404
  And the pet should not be deleted