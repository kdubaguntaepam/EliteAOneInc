@UI @Positive
Feature: Verify BlazeDemo Homepage Title
  As a user
  I want to verify the homepage title of BlazeDemo
  So that I can ensure the website is loading correctly

  Scenario: Verify the homepage title of BlazeDemo
    Given I navigate to "https://blazedemo.com/"
    Then the page title should be "BlazeDemo"