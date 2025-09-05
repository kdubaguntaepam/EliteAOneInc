Feature: Verify Pet Store Status Codes

  @API @Positive
  Scenario: Verify status code for creating a pet
    Given I have a pet creation payload with following details
      | Name    | Status | Category | Tags |
      | Buddy   | available | Dog     | friendly |
    When I send a POST request to create the pet
    Then the response status code should be 200
    And the pet should be created successfully

  @API @Positive
  Scenario: Verify status code for retrieving a pet
    Given I have successfully created a pet with the following details
      | Name    | Status | Category | Tags |
      | Buddy   | available | Dog     | friendly |
    When I retrieve the pet by ID
    Then the response status code should be 200
    And the pet details should be returned successfully

  @API @Positive
  Scenario: Verify status code for updating a pet
    Given I have successfully created a pet with the following details
      | Name    | Status | Category | Tags |
      | Buddy   | available | Dog     | friendly |
    When I update the pet with generated ID with new details
      | Name    | Status | Category | Tags |
      | Buddy   | sold    | Dog     | friendly |
    Then the response status code should be 200
    And the pet should be updated successfully

  @API @Positive
  Scenario: Verify status code for deleting a pet
    Given I have successfully created a pet with the following details
      | Name    | Status | Category | Tags |
      | Buddy   | available | Dog     | friendly |
    When I delete the pet with generated ID
    Then the response status code should be 200
    And the pet should be deleted successfully