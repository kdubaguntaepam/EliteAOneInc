Feature: PetStore Negative Scenarios
  @API @Negative
  Scenario: Retrieve pet with invalid ID
    Given the PetStore API is available and accessible
    And I set an invalid pet ID '999999'
    When I retrieve the pet by ID
    Then the response status code should be 404