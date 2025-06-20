@PetStoreAPI @Regression @APITesting
Feature: Verify Pet Store API Status Codes
  As an API consumer
  I want to verify the status codes for all Pet Store operations
  So that I can ensure the API is functioning correctly

Background:
  Given the PetStore API is available and accessible

@Smoke @CreatePet @PositiveScenario
Scenario Outline: Verify status code for