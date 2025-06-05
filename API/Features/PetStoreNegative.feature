#language: en

@API @Negative
Feature: Negative tests for PetStore API
  Scenario: Retrieve pet with invalid ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID 'invalidID'
    Then the response status code should be 404 for invalid ID
    And the response should contain an error message 'Pet not found'