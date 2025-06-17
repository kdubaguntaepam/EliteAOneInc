@UI @Positive
Feature: BlazeDemo Flight Booking

  Scenario: Successful Flight Search
    Given I navigate to 'https://blazedemo.com/'
    When I select 'departure city' as 'Boston' and 'destination city' as 'New York'
    And I click on 'Find Flights' button
    Then I should see the list of available flights

@UI @Negative
Feature: BlazeDemo Flight Booking

  Scenario: Unsuccessful Flight Search
    Given I navigate to 'https://blazedemo.com/'
    When I select 'departure city' as 'Boston' and 'destination city' as 'Paris'
    And I click on 'Find Flights' button
    Then I should see an error message indicating no flights are available