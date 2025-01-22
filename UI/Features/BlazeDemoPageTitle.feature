Feature: Verify the page title of BlazeDemo website

  Scenario: Verify the page title of BlazeDemo homepage
    Given I navigate to the BlazeDemo homepage
    Then the page title should be "BlazeDemo"