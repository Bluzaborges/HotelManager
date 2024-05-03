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
namespace HotelManager.Test.Users.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "User")]
    public partial class RemoveFineFeature : object, Xunit.IClassFixture<RemoveFineFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "User"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RemoveFine.feature"
#line hidden
        
        public RemoveFineFeature(RemoveFineFeature.FixtureData fixtureData, HotelManager_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Users/Features", "RemoveFine", "\tIn order to allow users to access our services\r\n\tAs an administrator\r\n\tI would l" +
                    "ike to unblock a user", ProgrammingLanguage.CSharp, new string[] {
                        "User"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Email",
                        "Password",
                        "Role",
                        "Cpf",
                        "Phone",
                        "Fine",
                        "Blocked",
                        "Deleted"});
            table39.AddRow(new string[] {
                        "Josh",
                        "josh@gmail.com",
                        "1234",
                        "Admin",
                        "77890464037",
                        "54926418694",
                        "0.00",
                        "False",
                        "False"});
            table39.AddRow(new string[] {
                        "Steve",
                        "steve@gmail.com",
                        "1234",
                        "Admin",
                        "48697613000",
                        "54934725422",
                        "0.00",
                        "False",
                        "False"});
            table39.AddRow(new string[] {
                        "Michael",
                        "michael@gmail.com",
                        "1234",
                        "Attendant",
                        "18116612034",
                        "51931696883",
                        "0.00",
                        "False",
                        "False"});
            table39.AddRow(new string[] {
                        "John",
                        "john@gmail.com",
                        "1234",
                        "Customer",
                        "70173805094",
                        "54927299016",
                        "0.00",
                        "False",
                        "False"});
            table39.AddRow(new string[] {
                        "Jim",
                        "jim@gmail.com",
                        "1234",
                        "Customer",
                        "53720760030",
                        "51928657841",
                        "300.00",
                        "False",
                        "False"});
            table39.AddRow(new string[] {
                        "Peter",
                        "peter@gmail.com",
                        "1234",
                        "Customer",
                        "27471571055",
                        "55931641434",
                        "0.00",
                        "True",
                        "False"});
#line 8
 testRunner.Given("these registered users", ((string)(null)), table39, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Remove fine from one user")]
        [Xunit.TraitAttribute("FeatureTitle", "RemoveFine")]
        [Xunit.TraitAttribute("Description", "Remove fine from one user")]
        public virtual void RemoveFineFromOneUser()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove fine from one user", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
#line 18
 testRunner.Given("I remove the fine from \"Jim\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
 testRunner.When("I execute the remove fine action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Fine"});
                table40.AddRow(new string[] {
                            "Josh",
                            "0.00"});
                table40.AddRow(new string[] {
                            "John",
                            "0.00"});
                table40.AddRow(new string[] {
                            "Jim",
                            "0.00"});
                table40.AddRow(new string[] {
                            "Peter",
                            "0.00"});
#line 20
 testRunner.Then("the users fine should be", ((string)(null)), table40, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RemoveFineFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RemoveFineFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
