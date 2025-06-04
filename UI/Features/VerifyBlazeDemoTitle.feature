#language: en
@UI @Positive
Feature: Verify BlazeDemo Homepage Title
  As a user
  I want to verify the title of the BlazeDemo homepage
  So that I can ensure I am on the correct page

  Scenario: Verify the title of BlazeDemo homepage
    Given I navigate to "https://blazedemo.com/"
    Then the page title should be "BlazeDemo"