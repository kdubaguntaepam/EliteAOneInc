@API @Positive
Feature: Verify PetStore API Status Codes

  Scenario: Verify status code for creating a pet
    Given the PetStore API is available and accessible
    And I have a pet creation payload with following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available | Dogs | cute |
    When I send a POST request to create the pet
    Then the response status code should be 200
    And the pet should be created successfully

  Scenario: Verify status code for retrieving a pet by ID
    Given the PetStore API is available and accessible
    And I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available | Dogs | cute |
    When I retrieve the pet by ID
    Then the response status code should be 200
    And the pet details should be returned successfully

  Scenario: Verify status code for updating a pet
    Given the PetStore API is available and accessible
    And I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available | Dogs | cute |
    When I update the pet with generated ID with new details
      | Name   | Status | Category | Tags  |
      | Fluffy | sold | Dogs | cute |
    Then the response status code should be 200
    And the pet should be updated successfully

  Scenario: Verify status code for deleting a pet
    Given the PetStore API is available and accessible
    And I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available | Dogs | cute |
    When I delete the pet with generated ID
    Then the response status code should be 200
    And the pet should be deleted successfully