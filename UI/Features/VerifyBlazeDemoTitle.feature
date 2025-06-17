#language: en

@UI @Positive
Feature: Verify BlazeDemo Page Title
  As a user
  I want to verify the page title of BlazeDemo
  So that I can ensure the website is loaded correctly

  Scenario: Verify the page title of BlazeDemo
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'

@UI @Negative
Feature: Verify Incorrect BlazeDemo Page Title
  As a user
  I want to verify the page title of BlazeDemo
  So that I can ensure the website is loaded correctly

  Scenario: Verify the incorrect page title of BlazeDemo
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should not be 'IncorrectTitle'