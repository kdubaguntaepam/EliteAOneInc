@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Status Code Verification
  As an API consumer
  I want to verify the status code for creating a new pet
  So that I can ensure the API responds correctly

@CreatePet @StatusCodeVerification @PositiveScenario
Scenario: Verify status code for creating a new pet with valid data
    Given I have a pet creation payload with the following details
        | Name      | Status      | Category | Tags      |
        | Bella     | available   | Dog      | Friendly  |
    When I send a POST request to create the pet
    Then the response status code should be 200
