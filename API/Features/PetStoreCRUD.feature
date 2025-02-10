@PetStoreAPI @Regression @APITesting
Feature: Pet Store API CRUD Operations
  As an API consumer
  I want to perform CRUD operations on pets
  So that I can manage pet information efficiently

Background:
  Given the PetStore API is available and accessible

@CRUDOperations @PositiveScenario
Scenario: Perform CRUD operations on a pet
  Given I have a pet creation payload with following details
    | Name      | Status      | Category | Tags      |
    | Buddy     | available   | Dog      | Friendly  |
  When I send a POST request to create the pet
  Then the response status code should be 200
  And the pet should be created successfully

  When I retrieve the pet by ID
  Then the pet details should be returned successfully

  When I update the pet with generated ID with new details
    | Name      | Status      | Category | Tags      |
    | Buddy     | sold        | Dog      | Friendly  |
  Then the pet should be updated successfully

  When I retrieve the pet by ID
  Then the pet details should be returned successfully

  When I delete the pet with generated ID
  Then the pet should be deleted successfully