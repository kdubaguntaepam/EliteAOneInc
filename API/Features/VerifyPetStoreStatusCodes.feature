@PetStoreAPI @StatusCodeVerification @APITesting
Feature: Verify Pet Store API Status Codes
  As an API tester
  I want to verify the status codes for all CRUD operations
  So that I can ensure the API behaves as expected

Background:
  Given the PetStore API is available and accessible

@CreatePet @StatusCode
Scenario Outline: Verify status code for creating a new pet
  Given I have a pet creation payload with following details
    | Name      | Status      | Category | Tags      |
    | <PetName> | <PetStatus> | <Breed>  | <PetTags> |
  When I send a POST request to create the pet
  Then the response status code should be 200

Examples:
  | PetName  | PetStatus | Breed | PetTags  |
  | Buddy    | available | Dog   | Friendly |

@RetrievePet @StatusCode
Scenario: Verify status code for retrieving an existing pet by ID
  Given I have successfully created a pet with the following details
    | Name    | Status    | Category | Tags     |
    | Charlie | available | Dog      | Friendly |
  When I retrieve the pet by ID
  Then the response status code should be 200

@UpdatePet @StatusCode
Scenario Outline: Verify status code for updating an existing pet
  Given I have successfully created a pet with the following details
    | Name      | Status      | Category | Tags   |
    | <OldName> | <OldStatus> | <Breed>  | <Tags> |
  When I update the pet with generated ID with new details
    | Name      | Status      | Category | Tags   |
    | <NewName> | <NewStatus> | <Breed>  | <Tags> |
  Then the response status code should be 200

Examples:
  | OldName | OldStatus | NewName  | NewStatus | Breed | Tags    |
  | Max     | available | Maximus  | sold      | Dog   | Guard   |

@DeletePet @StatusCode
Scenario: Verify status code for deleting an existing pet by ID
  Given I have successfully created a pet with the following details
    | Name  | Status    | Category | Tags |
    | Daisy | available | Bird     | Calm |
  When I delete the pet with generated ID
  Then the response status code should be 200
