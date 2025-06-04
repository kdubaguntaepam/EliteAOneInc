Feature: Verify BlazeDemo Page Title

  @UI @Positive
  Scenario: Verify correct page title
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'

  @UI @Negative
  Scenario: Verify incorrect page title
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should not be 'IncorrectTitle'