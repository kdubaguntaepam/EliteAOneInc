#language: en

@UI @Positive
Feature: BlazeDemo Positive Test Cases

  Scenario: Verify BlazeDemo Home Page Title
    Given I navigate to BlazeDemo home page
    Then the page title should be 'BlazeDemo'

@UI @Negative
Feature: BlazeDemo Negative Test Cases

  Scenario: Verify BlazeDemo Home Page Title with Incorrect Title
    Given I navigate to BlazeDemo home page
    Then the page title should not be 'IncorrectTitle'