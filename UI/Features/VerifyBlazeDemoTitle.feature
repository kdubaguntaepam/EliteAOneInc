Feature: Verify BlazeDemo Page Title

  @UI @Positive
  Scenario: Verify the page title is correct
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'

  @UI @Negative
  Scenario: Verify the page title is incorrect
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should not be 'IncorrectTitle'