@RetrievePet @StatusCodeVerification
Scenario: Verify the status code when retrieving an existing pet by valid ID
    Given I have successfully created a pet with the following details
        | Name    | Status    | Category | Tags     |
        | Bella   | available | Dog      | Friendly |
    When I retrieve the pet by ID
    Then the response status code should be 200