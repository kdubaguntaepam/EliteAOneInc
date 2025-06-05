@UI @Positive
Feature: Verify SauceDemo Page Title

  Scenario: Verify the page title is 'Swag Labs'
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should be 'Swag Labs'

@UI @Negative
  Scenario: Verify the page title is not 'Swag Lab'
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should not be 'Swag Lab'