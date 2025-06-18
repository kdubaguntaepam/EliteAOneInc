#language: en
@API @Positive
Feature: Verify Pet Store API Status Codes
  Verify that all operations in the Pet Store API return the correct status codes.

  @Positive
  Scenario: Verify status code for creating a pet
    Given the PetStore API is available and accessible
    And I have a pet creation payload with following details
      | Name   | Status | Category | Tags  |
      | Buddy  | available | Dogs    | Tag1 |
    When I send a POST request to create the pet
    Then the response status code should be 200
    And the pet should be created successfully

  @Positive
  Scenario: Verify status code for retrieving a pet by ID
    Given I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Buddy  | available | Dogs    | Tag1 |
    When I retrieve the pet by ID
    Then the response status code should be 200
    And the pet details should be returned successfully

  @Positive
  Scenario: Verify status code for updating a pet
    Given I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Buddy  | available | Dogs    | Tag1 |
    When I update the pet with generated ID with new details
      | Name   | Status | Category | Tags  |
      | Buddy  | sold    | Dogs    | Tag2 |
    Then the response status code should be 200
    And the pet should be updated successfully

  @Positive
  Scenario: Verify status code for deleting a pet
    Given I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Buddy  | available | Dogs    | Tag1 |
    When I delete the pet with generated ID
    Then the response status code should be 200
    And the pet should be deleted successfully
