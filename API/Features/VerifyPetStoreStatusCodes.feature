@API @Positive
Feature: Verify status codes for all Pet Store operations
  As an API consumer
  I want to verify the status codes for all Pet Store operations
  So that I can ensure the API is functioning correctly

Background:
  Given the PetStore API is available and accessible

@CreatePet @Positive
Scenario Outline: Verify status code for creating a new pet
  Given I have a pet creation payload with following details
    | Name      | Status      | Category | Tags      |
    | <PetName> | <PetStatus> | <Breed>  | <PetTags> |
  When I send a POST request to create the pet
  Then the response status code should be 200
  And the pet should be created successfully

Examples:
  | PetName  | PetStatus | Breed | PetTags  |
  | Buddy    | available | Dog   | Friendly |
  | Whiskers | pending   | Cat   | Playful  |
  | Rex      | sold      | Dog   | Guardian |

@RetrievePet @Positive
Scenario: Verify status code for retrieving an existing pet
  Given I have successfully created a pet with the following details
    | Name    | Status    | Category | Tags     |
    | Charlie | available | Dog      | Friendly |
  When I retrieve the pet by ID
  Then the response status code should be 200
  And the pet details should be returned successfully

@UpdatePet @Positive
Scenario Outline: Verify status code for updating an existing pet
  Given I have successfully created a pet with the following details
    | Name      | Status      | Category | Tags   |
    | <OldName> | <OldStatus> | <Breed>  | <Tags> |
  When I update the pet with generated ID with new details
    | Name      | Status      | Category | Tags   |
    | <NewName> | <NewStatus> | <Breed>  | <Tags> |
  Then the response status code should be 200
  And the pet should be updated successfully

Examples:
  | OldName | OldStatus | NewName  | NewStatus | Breed | Tags    |
  | Max     | available | Maximus  | sold      | Dog   | Guard   |
  | Kitty   | pending   | Princess | available | Cat   | Playful |

@DeletePet @Positive
Scenario: Verify status code for deleting an existing pet
  Given I have successfully created a pet with the following details
    | Name  | Status    | Category | Tags |
    | Daisy | available | Bird     | Calm |
  When I delete the pet with generated ID
  Then the response status code should be 200
  And the pet should be deleted successfully
