@UI
Feature: Verify SauceDemo Page Title
  As a user
  I want to verify the page title of SauceDemo
  So that I can ensure the correct page is loaded

  @Positive
  Scenario: Verify the page title is correct
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should be 'Swag Labs'

  @Negative
  Scenario: Verify the page title is incorrect
    Given I navigate to 'https://www.saucedemo.com/'
    Then the page title should not be 'Incorrect Title'