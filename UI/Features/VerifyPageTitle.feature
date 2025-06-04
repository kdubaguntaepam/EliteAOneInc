Feature: Verify Page Title
  Scenario: Verify the page title of Blazedemo
    Given I navigate to "https://blazedemo.com/"
    Then the page title should be "BlazeDemo"