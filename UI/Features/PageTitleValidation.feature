@UI
Feature: Page Title Validation
  As a user
  I want to validate the page title of BlazeDemo
  So that I can ensure the correct page is loaded

  @Positive @PageTitle
  Scenario: Validate BlazeDemo page title
    Given I navigate to "https://blazedemo.com/"
    Then the page title should be "BlazeDemo"
