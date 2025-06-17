Feature: BlazeDemo Flight Booking

  Scenario: Positive Test - Book a flight successfully
    Given I am on the BlazeDemo homepage
    When I select departure city as "Boston" and destination city as "New York"
    And I click on "Find Flights"
    Then I should see a list of available flights
    When I choose the first flight
    And I enter my details and purchase the flight
    Then I should see a confirmation message with the booking details

  Scenario: Negative Test - Book a flight with missing details
    Given I am on the BlazeDemo homepage
    When I select departure city as "Boston" and destination city as "New York"
    And I click on "Find Flights"
    Then I should see a list of available flights
    When I choose the first flight
    And I leave the details form empty and purchase the flight
    Then I should see an error message indicating missing details