Feature: Negative Pet Retrieval

  Scenario: Retrieve non-existent pet
    Given I send a GET request to endpoint '/pet/999999'
    Then the response status code should be 404
    And the response should contain 'Pet not found'