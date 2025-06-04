@UI @Positive
Feature: Verify Page Title
  As a user
  I want to verify the page title of the BlazeDemo website

  Scenario: Verify BlazeDemo page title
    Given I navigate to "https://blazedemo.com/"
    Then the title should be "BlazeDemo"