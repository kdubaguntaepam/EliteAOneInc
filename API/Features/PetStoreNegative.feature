@PetStoreAPI @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to handle errors gracefully
  So that I can ensure robustness of the API

Background:
  Given the PetStore API is available and accessible

@RetrievePet @NegativeScenario
Scenario: Retrieve a non-existing pet by invalid ID
  Given I have an invalid pet ID
  When I retrieve the pet by invalid ID
  Then the response status code should be 404 for invalid pet ID
  And the error message should indicate pet not found
