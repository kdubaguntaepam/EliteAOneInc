Feature: Pet Retrieval Negative Test
  @API @Negative
  Scenario: Retrieve a pet with non-existent ID
    Given the PetStore API is available and accessible
    When I retrieve the pet by ID '999999999'
    Then the response status code should be 404
    And the error message should be 'Pet not found'