@UI
Feature: New Gmail Login Functionality
  As a Gmail user
  I want to log in to my account
  So that I can access my inbox

  @Negative @FailedLogin
  Scenario: Unsuccessful login with invalid credentials
    Given I navigate to Gmail login page
    When I enter "invaliduser@gmail.com" and "WrongPassword"
    Then I should see an error message
