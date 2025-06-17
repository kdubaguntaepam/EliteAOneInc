Feature: Negative Pet Retrieval Scenarios
  @API @Negative
  Scenario: Retrieve a non-existent pet by ID
    Given I have the pet ID '999999'
    When I retrieve the pet by ID
    Then the response status code should be '404'
    And the response message should be 'Pet not found'