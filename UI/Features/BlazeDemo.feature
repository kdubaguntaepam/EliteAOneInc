# BlazeDemo.feature

Feature: BlazeDemo Tests

  @UI @Positive
  Scenario: Verify BlazeDemo Home Page Title
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'

  @UI @Negative
  Scenario: Verify BlazeDemo Home Page Title with Incorrect Title
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should not be 'Incorrect Title'