@PageTitle @UITesting
Feature: Validate Page Title
  As a user
  I want to verify the page title of BlazeDemo
  So that I can ensure the correct page is loaded

Scenario: Verify the page title of BlazeDemo homepage
  Given I navigate to the BlazeDemo homepage
  Then the page title should be "BlazeDemo"
