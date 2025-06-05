@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Operations
  As an API consumer
  I want to handle errors gracefully when performing CRUD operations on pets
  So that I can ensure robustness of the API

Background:
  Given the PetStore API is available and accessible

@Smoke @CreatePet @NegativeScenario
Scenario Outline: Fail to create a new pet with invalid data
  Given I have a pet creation payload with invalid details
    | Name      | Status      | Category | Tags      |
    | <PetName> | <PetStatus> | <Breed>  | <PetTags> |
  When I send a POST request to create the pet
  Then the response status code should be 400
  And the pet should not be created

Examples:
  | PetName  | PetStatus | Breed | PetTags  |
  |          | available | Dog   | Friendly |
  | Whiskers |           | Cat   | Playful  |
  | Rex      | sold      |       | Guardian |

@RetrievePet @NegativeScenario
Scenario: Fail to retrieve a non-existing pet by invalid ID
  Given I have an invalid pet ID
  When I retrieve the pet by ID
  Then the response status code should be 404
  And the pet details should not be returned

@UpdatePet @NegativeScenario
Scenario Outline: Fail to update a non-existing pet with new details
  Given I have an invalid pet ID
  When I update the pet with invalid ID with new details
    | Name      | Status      | Category | Tags   |
    | <NewName> | <NewStatus> | <Breed>  | <Tags> |
  Then the response status code should be 404
  And the pet should not be updated

Examples:
  | NewName  | NewStatus | Breed | Tags    |
  | Maximus  | sold      | Dog   | Guard   |
  | Princess | available | Cat   | Playful |

@DeletePet @NegativeScenario
Scenario: Fail to delete a non-existing pet by invalid ID
  Given I have an invalid pet ID
  When I delete the pet with invalid ID
  Then the response status code should be 404
  And the pet should not be deleted