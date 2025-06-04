@UI @Regression @Blazedemo
Feature: Blazedemo Page Title Verification
  As a user
  I want to verify the page title of Blazedemo
  So that I can ensure I'm on the correct website

Scenario: Verify Blazedemo page title
  Given I navigate to the Blazedemo website
  Then the page title should be "BlazeDemo"