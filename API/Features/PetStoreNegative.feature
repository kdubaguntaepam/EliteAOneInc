#language: en

@API @Negative
Feature: PetStore Negative Scenarios
  As a user of the PetStore API
  I want to ensure that invalid operations are handled gracefully
  So that the system remains robust and secure

  Scenario: Retrieve pet with invalid ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID 'invalidID'
    Then the response status code should be 404
    And the response should contain an error message 'Pet not found'