Feature: Negative tests for Pet retrieval

  Scenario: Retrieve non-existent pet
    Given I send a GET request to endpoint '/pet/999999'
    Then the response status code should be 404
    And the response body should contain error message 'Pet not found'