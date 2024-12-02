@CreateVendorAPI
Feature: Create Vendor API

Scenario: Create Vendor with valid details
Given I am logged in to ClaimsPay API as DEFAULT user
When I call CreateVendor method with 'Vendor' with below values
	| Business TIN   | Business Sub Type   |
	| <Business TIN> | <Business Sub Type> |
Then I should get 'Success' status in CreateVendor response