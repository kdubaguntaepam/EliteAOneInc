@PageTitle @UI @Regression
Feature: Validate Page Title
  As a user
  I want to validate the page title of BlazeDemo website
  So that I can ensure the correct title is displayed

@Smoke @PageTitle
Scenario: Validate the page title of BlazeDemo
  Given I navigate to the BlazeDemo website
  Then the page title should be "BlazeDemo"
