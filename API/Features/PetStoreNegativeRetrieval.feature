#language: en

@API @Negative
Feature: Negative Pet Retrieval
  As a user of the PetStore API
  I want to ensure that retrieving a non-existent pet returns the correct error response

  Scenario: Retrieve a pet with an invalid ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID '999999999999'
    Then the response status code should be 404
    And the response error message should be 'Pet not found'