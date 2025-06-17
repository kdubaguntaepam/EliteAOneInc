@PetStoreAPI @Regression @APITesting @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to handle errors gracefully
  So that I can ensure the API responds correctly to invalid requests

Background:
  Given the PetStore API is available and accessible

@RetrievePet @NegativeScenario
Scenario: Retrieve a non-existent pet by invalid ID
  Given I have an invalid pet ID
  When I retrieve the pet by ID
  Then the response status code should be 404
  And the error message should indicate that the pet was not found