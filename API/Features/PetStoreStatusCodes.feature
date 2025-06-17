Feature: Verify status codes for all PetStore operations

  @API @Positive
  Scenario: Verify status code for creating a pet
    Given I have a pet with ID '12345' and name 'Buddy'
    When I create the pet
    Then the response status code should be '200'

  @API @Positive
  Scenario: Verify status code for retrieving a pet by ID
    Given I have a pet with ID '12345'
    When I retrieve the pet by ID '12345'
    Then the response status code should be '200'

  @API @Negative
  Scenario: Verify status code for retrieving a non-existent pet by ID
    Given I have an invalid pet ID '999999'
    When I retrieve the pet by ID '999999'
    Then the response status code should be '404'

  @API @Positive
  Scenario: Verify status code for updating a pet
    Given I have a pet with ID '12345' and name 'Buddy'
    When I update the pet with new name 'Max'
    Then the response status code should be '200'

  @API @Positive
  Scenario: Verify status code for deleting a pet
    Given I have a pet with ID '12345'
    When I delete the pet by ID '12345'
    Then the response status code should be '200'