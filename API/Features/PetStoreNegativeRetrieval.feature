#language: en

@API @Negative
Feature: Negative Pet Retrieval Scenarios
  As a user of the PetStore API
  I want to ensure that retrieving a pet with invalid ID returns appropriate error messages

  Scenario: Retrieve pet with non-existent ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID '999999'
    Then the response status code should be 404 for invalid pet ID
    And the response error message should indicate 'Pet not found'