@API @Negative
Feature: Negative Pet Retrieval

  Scenario: Retrieve non-existent pet by ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID '999999'
    Then the response status code should be 404
    And the response should contain an error message 'Pet not found'
