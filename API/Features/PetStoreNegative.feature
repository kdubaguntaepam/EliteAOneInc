# language: en

@API @Negative
Feature: PetStore API Negative Scenarios
  As a user of the PetStore API
  I want to ensure that invalid operations are handled gracefully
  So that I receive appropriate error messages and status codes

  Scenario: Retrieve pet with invalid long integer ID
    Given I have an invalid long integer pet ID
    When I retrieve the pet by ID
    Then the response status code should be 404
    And the response error message should be 'Pet not found'