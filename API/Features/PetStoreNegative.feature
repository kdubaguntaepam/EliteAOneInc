@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Operations
  As an API consumer
  I want to handle errors when performing CRUD operations on pets
  So that I can ensure the API handles invalid inputs gracefully

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
  |          | available | Dog   | Friendly |
  | Whiskers |           | Cat   | Playful  |
  | Rex      | sold      |       | Guardian |

@RetrievePet @NegativeScenario
Scenario: Fail to retrieve a pet by invalid ID
  Given I have an invalid pet ID
  When I retrieve the pet by ID
  Then the response status code should not be 200
  And the pet details should not be returned

@UpdatePet @NegativeScenario
Scenario Outline: Fail to update a pet with invalid details
  Given I have successfully created a pet with the following details
    | Name      | Status      | Category | Tags   |
    | <OldName> | <OldStatus> | <Breed>  | <Tags> |
  When I update the pet with generated ID with invalid details
    | Name      | Status      | Category | Tags   |
    | <NewName> | <NewStatus> | <Breed>  | <Tags> |
  Then the response status code should not be 200
  And the pet should not be updated

Examples:
  | OldName | OldStatus | NewName  | NewStatus | Breed | Tags    | PetID |
  | Max     | available |          | sold      | Dog   | Guard   | 1234  |
  | Kitty   | pending   | Princess |           | Cat   | Playful | 5678  |

@DeletePet @NegativeScenario
Scenario: Fail to delete a pet by invalid ID
  Given I have an invalid pet ID
  When I delete the pet with generated ID
  Then the response status code should not be 200
  And the pet should not be deleted