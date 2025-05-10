@PageTitle @Regression @UITesting
Feature: Validate Page Title
  As a user
  I want to validate the page title of BlazeDemo
  So that I can ensure the correct page is loaded

@PageTitle @PositiveScenario
Scenario: Validate the page title of BlazeDemo
  Given I navigate to the BlazeDemo homepage
  Then the page title should be "BlazeDemo"
