Feature: Verify BlazeDemo Page Title

  @UI @Positive
  Scenario: Verify the page title of BlazeDemo
    Given I navigate to BlazeDemo page
    Then the page title should be 'BlazeDemo'
