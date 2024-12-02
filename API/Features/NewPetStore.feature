Feature: PetStore API Negative Scenarios for Delete Operation

  Scenario: Delete a non-existent pet
    Given I have the PetStore API endpoint
    When I send a DELETE request for a pet with ID 999999
    Then the response status code should be 404
    And the response body should contain "Pet not found"

  Scenario: Delete a pet with invalid ID
    Given I have the PetStore API endpoint
    When I send a DELETE request for a pet with ID "invalidID"
    Then the response status code should be 400
    And the response body should contain "Invalid ID supplied"