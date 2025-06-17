@UI @Positive
Feature: BlazeDemo Positive Test Cases

  Scenario: Verify BlazeDemo Flight Search
    Given I navigate to 'https://blazedemo.com/'
    When I select departure city as 'Boston' and destination city as 'New York'
    And I click on 'Find Flights' button
    Then I should see the list of available flights

@UI @Negative
Feature: BlazeDemo Negative Test Cases

  Scenario: Verify BlazeDemo Flight Search with Invalid Cities
    Given I navigate to 'https://blazedemo.com/'
    When I select departure city as 'InvalidCity' and destination city as 'New York'
    And I click on 'Find Flights' button
    Then I should see an error message for invalid city selection