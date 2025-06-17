@API @Positive
Feature: Verify Status Codes for Pet Store Operations

  Scenario: Verify status code for creating a pet
    Given the PetStore API is available and accessible
    And I have a pet creation payload with following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available | Dogs | cute |
    When I send a POST request to create the pet
    Then the response status code should be 200
    And the pet should be created successfully

  Scenario: Verify status code for retrieving a pet by ID
    Given I have successfully created a pet with the following details
      | Name   | Status | Category | Tags  |
      | Fluffy | available |