Feature: Verify Pet Store API Status Codes
  @API @Positive
  Scenario: Verify status codes for all Pet Store operations
    Given the PetStore API is available and accessible
    Given I have a pet creation payload with following details
      | Name  | Status | Category | Tags  |
      | Doggo | available | Dogs | Tag1 |
    When I send a POST request to create the pet
    Then the response status code should be 200
    Then the pet should be created successfully

    Given I have successfully created a pet with the following details
      | Name  | Status | Category | Tags  |
      | Doggo | available | Dogs | Tag1 |
    When I retrieve the pet by ID
    Then the response status code should be 200
    Then the pet details should be returned successfully

    When I update the pet with generated ID with new details
      | Name  | Status | Category | Tags  |
      | DoggoUpdated | sold | Dogs | Tag2 |
    Then the response status code should be 200
    Then the pet should be updated successfully

    When I delete the pet with generated ID
    Then the response status code should be 200
    Then the pet should be deleted successfully