Feature: Negative Pet Retrieval
  Scenario: Retrieve a pet with an invalid ID
    Given I have an invalid pet ID 'invalid_id'
    When I retrieve the pet by ID 'invalid_id'
    Then I should receive a 404 Not Found response