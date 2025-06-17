@UI @Positive
Feature: Verify BlazeDemo Page Title
  As a user
  I want to verify the title of the BlazeDemo homepage
  So that I can ensure the page loads correctly

  Scenario: Verify the title of BlazeDemo homepage
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'

@UI @Negative
Feature: Verify BlazeDemo Page Title with Incorrect URL
  As a user
  I want to verify the title of the BlazeDemo homepage with an incorrect URL
  So that I can ensure the page does not load correctly

  Scenario: Verify the title of BlazeDemo homepage with incorrect URL
    Given I navigate to 'https://blazedemo.com/incorrect'
    Then the page title should not be 'BlazeDemo'