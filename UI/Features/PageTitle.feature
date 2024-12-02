Feature: Validate Page Title of BlazeDemo

  Scenario: Verify the page title of BlazeDemo
    Given I navigate to "https://blazedemo.com/"
    Then the page title should be "BlazeDemo"