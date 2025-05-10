@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Status Code Verification
  As an API consumer
  I want to verify the status code for retrieving a pet
  So that I can ensure the API returns the correct status code

@RetrievePetStatusCode @PositiveScenario
Scenario: Verify status code for retrieving an existing pet by valid ID
    Given I have successfully created a pet with the following details
        | Name    | Status    | Category | Tags     |
        | Bella   | available | Dog      | Friendly |
    When I retrieve the pet by ID
    Then the response status code should be 200
