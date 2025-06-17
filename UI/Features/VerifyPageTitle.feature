#language: en

@UI @Positive
Feature: Verify Page Title
  As a user
  I want to verify the page title of the BlazeDemo website
  So that I can ensure the correct page is loaded

  Scenario: Verify the page title of BlazeDemo
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'