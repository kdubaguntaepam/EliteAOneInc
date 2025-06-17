#language: en

@UI @Positive
Feature: Verify BlazeDemo Page Title
  As a user
  I want to verify the page title of BlazeDemo
  So that I can ensure I am on the correct page

  Scenario: Verify BlazeDemo page title
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'