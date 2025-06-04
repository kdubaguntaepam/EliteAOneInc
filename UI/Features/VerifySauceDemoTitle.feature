@UI @Positive
Feature: Verify SauceDemo Page Title

  Scenario: Verify the page title is correct
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should be 'Swag Labs'

  @Negative
  Scenario: Verify the page title is incorrect
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should not be 'Incorrect Title'