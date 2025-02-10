Feature: Combined CRUD Operations on PetStore API

  Scenario: Complete CRUD operations for a store
    Given I have created a new store
    When I retrieve the store
    And I update the store
    And I retrieve the updated store
    Then I delete the store
    And I verify the deletion status