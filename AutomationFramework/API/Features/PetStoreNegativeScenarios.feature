@PetStoreAPI @Regression @APITesting @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to verify the negative scenarios for PetStore API
  So that I can ensure the API handles errors gracefully

@RetrievePet @NegativeScenario
Scenario: Retrieve a pet with an invalid ID
  Given the PetStore API is available and accessible
  When I retrieve the pet by ID with an invalid ID
  Then the response status code should be 404

@RetrievePet @NegativeScenario
Scenario: Retrieve a pet with a non-existent ID
  Given the PetStore API is available and accessible
  When I retrieve the pet by ID with a non-existent ID
  Then the response status code should be 404