
@UI
Feature: Page Title Verification
  As a user
  I want to verify the page title of BlazeDemo
  So that I can ensure the correct page is loaded

  @Positive @PageTitle
  Scenario: Verify the page title of BlazeDemo
    Given I navigate to BlazeDemo homepage
    Then the page title should be "BlazeDemo"