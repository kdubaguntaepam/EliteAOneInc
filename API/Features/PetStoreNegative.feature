@API @Negative
Feature: PetStore API Negative Tests

  Scenario: Retrieve a pet with an invalid ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID '999999999'
    Then the response status code should be 404
    And the response should contain an error message 'Pet not found'