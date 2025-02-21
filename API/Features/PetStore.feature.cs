﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AutomationFramework.API.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Pet Store API Operations")]
    [NUnit.Framework.CategoryAttribute("PetStoreAPI")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("APITesting")]
    public partial class PetStoreAPIOperationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "PetStoreAPI",
                "Regression",
                "APITesting"};
        
#line 1 "PetStore.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "API/Features", "Pet Store API Operations", "  As an API consumer\r\n  I want to perform CRUD operations on pets\r\n  So that I ca" +
                    "n manage pet information efficiently", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
#line 8
 testRunner.Given("the PetStore API is available and accessible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Successfully create a new pet with valid data")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        [NUnit.Framework.CategoryAttribute("CreatePet")]
        [NUnit.Framework.CategoryAttribute("PositiveScenario")]
        [NUnit.Framework.TestCaseAttribute("Buddy", "available", "Dog", "Friendly", null)]
        [NUnit.Framework.TestCaseAttribute("Whiskers", "pending", "Cat", "Playful", null)]
        [NUnit.Framework.TestCaseAttribute("Rex", "sold", "Dog", "Guardian", null)]
        public void SuccessfullyCreateANewPetWithValidData(string petName, string petStatus, string breed, string petTags, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Smoke",
                    "CreatePet",
                    "PositiveScenario"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("PetName", petName);
            argumentsOfScenario.Add("PetStatus", petStatus);
            argumentsOfScenario.Add("Breed", breed);
            argumentsOfScenario.Add("PetTags", petTags);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successfully create a new pet with valid data", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Status",
                            "Category",
                            "Tags"});
                table1.AddRow(new string[] {
                            string.Format("{0}", petName),
                            string.Format("{0}", petStatus),
                            string.Format("{0}", breed),
                            string.Format("{0}", petTags)});
#line 12
 testRunner.Given("I have a pet creation payload with following details", ((string)(null)), table1, "Given ");
#line hidden
#line 15
 testRunner.When("I send a POST request to create the pet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.Then("the response status code should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.And("the pet should be created successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve an existing pet by valid ID")]
        [NUnit.Framework.CategoryAttribute("RetrievePet")]
        [NUnit.Framework.CategoryAttribute("PositiveScenario")]
        public void RetrieveAnExistingPetByValidID()
        {
            string[] tagsOfScenario = new string[] {
                    "RetrievePet",
                    "PositiveScenario"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve an existing pet by valid ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Status",
                            "Category",
                            "Tags"});
                table2.AddRow(new string[] {
                            "Charlie",
                            "available",
                            "Dog",
                            "Friendly"});
#line 27
 testRunner.Given("I have successfully created a pet with the following details", ((string)(null)), table2, "Given ");
#line hidden
#line 30
 testRunner.When("I retrieve the pet by ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.Then("the pet details should be returned successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update an existing pet with new details")]
        [NUnit.Framework.CategoryAttribute("UpdatePet")]
        [NUnit.Framework.CategoryAttribute("PositiveScenario")]
        [NUnit.Framework.TestCaseAttribute("Max", "available", "Maximus", "sold", "Dog", "Guard", "1234", null)]
        [NUnit.Framework.TestCaseAttribute("Kitty", "pending", "Princess", "available", "Cat", "Playful", "5678", null)]
        public void UpdateAnExistingPetWithNewDetails(string oldName, string oldStatus, string newName, string newStatus, string breed, string tags, string petID, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UpdatePet",
                    "PositiveScenario"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("OldName", oldName);
            argumentsOfScenario.Add("OldStatus", oldStatus);
            argumentsOfScenario.Add("NewName", newName);
            argumentsOfScenario.Add("NewStatus", newStatus);
            argumentsOfScenario.Add("Breed", breed);
            argumentsOfScenario.Add("Tags", tags);
            argumentsOfScenario.Add("PetID", petID);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update an existing pet with new details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Status",
                            "Category",
                            "Tags"});
                table3.AddRow(new string[] {
                            string.Format("{0}", oldName),
                            string.Format("{0}", oldStatus),
                            string.Format("{0}", breed),
                            string.Format("{0}", tags)});
#line 35
 testRunner.Given("I have successfully created a pet with the following details", ((string)(null)), table3, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Status",
                            "Category",
                            "Tags"});
                table4.AddRow(new string[] {
                            string.Format("{0}", newName),
                            string.Format("{0}", newStatus),
                            string.Format("{0}", breed),
                            string.Format("{0}", tags)});
#line 38
 testRunner.When("I update the pet with generated ID with new details", ((string)(null)), table4, "When ");
#line hidden
#line 41
 testRunner.Then("the pet should be updated successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete an existing pet by valid ID")]
        [NUnit.Framework.CategoryAttribute("DeletePet")]
        [NUnit.Framework.CategoryAttribute("PositiveScenario")]
        public void DeleteAnExistingPetByValidID()
        {
            string[] tagsOfScenario = new string[] {
                    "DeletePet",
                    "PositiveScenario"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete an existing pet by valid ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Status",
                            "Category",
                            "Tags"});
                table5.AddRow(new string[] {
                            "Daisy",
                            "available",
                            "Bird",
                            "Calm"});
#line 50
 testRunner.Given("I have successfully created a pet with the following details", ((string)(null)), table5, "Given ");
#line hidden
#line 53
 testRunner.When("I delete the pet with generated ID", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
 testRunner.Then("the pet should be deleted successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
