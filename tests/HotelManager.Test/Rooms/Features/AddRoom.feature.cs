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
namespace HotelManager.Test.Rooms.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "Room")]
    public partial class AddRoomFeature : object, Xunit.IClassFixture<AddRoomFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Room"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AddRoom.feature"
#line hidden
        
        public AddRoomFeature(AddRoomFeature.FixtureData fixtureData, HotelManager_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Rooms/Features", "AddRoom", "\tIn order to make a new room available to be reserved\r\n\tAs a admin\r\n\tI want to ad" +
                    "d a room", ProgrammingLanguage.CSharp, new string[] {
                        "Room"});
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
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Type",
                        "Name",
                        "Value"});
            table14.AddRow(new string[] {
                        "1",
                        "Deluxe",
                        "Luxo",
                        "150.00"});
            table14.AddRow(new string[] {
                        "2",
                        "Conventional",
                        "Convencional",
                        "98.00"});
#line 8
 testRunner.Given("these room values", ((string)(null)), table14, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Code",
                        "RoomValue",
                        "Deleted"});
            table15.AddRow(new string[] {
                        "1A",
                        "1",
                        "False"});
            table15.AddRow(new string[] {
                        "2A",
                        "1",
                        "False"});
            table15.AddRow(new string[] {
                        "1B",
                        "2",
                        "False"});
            table15.AddRow(new string[] {
                        "2B",
                        "2",
                        "False"});
            table15.AddRow(new string[] {
                        "3B",
                        "2",
                        "False"});
#line 12
 testRunner.And("these rooms", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Email",
                        "Password",
                        "Role",
                        "Cpf",
                        "Phone",
                        "Fine",
                        "Blocked"});
            table16.AddRow(new string[] {
                        "Josh",
                        "josh@gmail.com",
                        "1234",
                        "Admin",
                        "77890464037",
                        "54926418694",
                        "0.00",
                        "False"});
            table16.AddRow(new string[] {
                        "John",
                        "john@gmail.com",
                        "1234",
                        "Customer",
                        "70173805094",
                        "54927299016",
                        "0.00",
                        "False"});
            table16.AddRow(new string[] {
                        "Jim",
                        "jim@gmail.com",
                        "1234",
                        "Customer",
                        "53720760030",
                        "51928657841",
                        "0.00",
                        "False"});
            table16.AddRow(new string[] {
                        "Peter",
                        "peter@gmail.com",
                        "1234",
                        "Customer",
                        "27471571055",
                        "55931641434",
                        "0.00",
                        "False"});
#line 19
 testRunner.And("these registered users", ((string)(null)), table16, "And ");
#line hidden
#line 25
 testRunner.And("all reservations start in 12 hours from now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("all reservations ends after 5 days from start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Reservation",
                        "Room",
                        "User",
                        "Deleted"});
            table17.AddRow(new string[] {
                        "1",
                        "1A",
                        "Jim",
                        "False"});
            table17.AddRow(new string[] {
                        "2",
                        "1B",
                        "Jim",
                        "False"});
            table17.AddRow(new string[] {
                        "3",
                        "2A",
                        "John",
                        "False"});
            table17.AddRow(new string[] {
                        "4",
                        "2B",
                        "John",
                        "False"});
#line 27
 testRunner.And("these reservations", ((string)(null)), table17, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add a room with existing code")]
        [Xunit.TraitAttribute("FeatureTitle", "AddRoom")]
        [Xunit.TraitAttribute("Description", "Add a room with existing code")]
        public virtual void AddARoomWithExistingCode()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a room with existing code", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 34
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
#line 35
 testRunner.Given("the code is \"1A\" and the type is \"Deluxe\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.When("I add the room", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.Then("I\'m told there are rooms registered with the code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                AddRoomFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AddRoomFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
