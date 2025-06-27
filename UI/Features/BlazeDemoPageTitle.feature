@UI @Positive
Feature: BlazeDemo Page Title Verification

  Scenario: Verify the page title of BlazeDemo
    Given I navigate to 'https://blazedemo.com/'
    Then the page title should be 'BlazeDemo'
