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
    public partial class DeleteRoomFeature : object, Xunit.IClassFixture<DeleteRoomFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Room"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DeleteRoom.feature"
#line hidden
        
        public DeleteRoomFeature(DeleteRoomFeature.FixtureData fixtureData, HotelManager_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Rooms/Features", "DeleteRoom", "\tIn order to make a new room unavailable to be reserved\r\n\tAs a admin\r\n\tI want to " +
                    "delete a room", ProgrammingLanguage.CSharp, new string[] {
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
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Type",
                        "Name",
                        "Value"});
            table18.AddRow(new string[] {
                        "1",
                        "Deluxe",
                        "Luxo",
                        "150.00"});
            table18.AddRow(new string[] {
                        "2",
                        "Conventional",
                        "Convencional",
                        "98.00"});
#line 8
 testRunner.Given("these room values", ((string)(null)), table18, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Code",
                        "RoomValue",
                        "Deleted"});
            table19.AddRow(new string[] {
                        "1A",
                        "1",
                        "False"});
            table19.AddRow(new string[] {
                        "2A",
                        "1",
                        "False"});
            table19.AddRow(new string[] {
                        "1B",
                        "2",
                        "False"});
            table19.AddRow(new string[] {
                        "2B",
                        "2",
                        "False"});
            table19.AddRow(new string[] {
                        "3B",
                        "2",
                        "False"});
#line 12
 testRunner.And("these rooms", ((string)(null)), table19, "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Email",
                        "Password",
                        "Role",
                        "Cpf",
                        "Phone",
                        "Fine",
                        "Blocked"});
            table20.AddRow(new string[] {
                        "Josh",
                        "josh@gmail.com",
                        "1234",
                        "Admin",
                        "77890464037",
                        "54926418694",
                        "0.00",
                        "False"});
            table20.AddRow(new string[] {
                        "John",
                        "john@gmail.com",
                        "1234",
                        "Customer",
                        "70173805094",
                        "54927299016",
                        "0.00",
                        "False"});
            table20.AddRow(new string[] {
                        "Jim",
                        "jim@gmail.com",
                        "1234",
                        "Customer",
                        "53720760030",
                        "51928657841",
                        "0.00",
                        "False"});
            table20.AddRow(new string[] {
                        "Peter",
                        "peter@gmail.com",
                        "1234",
                        "Customer",
                        "27471571055",
                        "55931641434",
                        "0.00",
                        "False"});
#line 19
 testRunner.And("these registered users", ((string)(null)), table20, "And ");
#line hidden
#line 25
 testRunner.And("all reservations start in 12 hours from now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("all reservations ends after 5 days from start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Reservation",
                        "Room",
                        "User",
                        "Deleted"});
            table21.AddRow(new string[] {
                        "1",
                        "1A",
                        "Jim",
                        "False"});
            table21.AddRow(new string[] {
                        "2",
                        "1B",
                        "Jim",
                        "False"});
            table21.AddRow(new string[] {
                        "3",
                        "2A",
                        "John",
                        "False"});
            table21.AddRow(new string[] {
                        "4",
                        "2B",
                        "John",
                        "False"});
#line 27
 testRunner.And("these reservations", ((string)(null)), table21, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Delete one room")]
        [Xunit.TraitAttribute("FeatureTitle", "DeleteRoom")]
        [Xunit.TraitAttribute("Description", "Delete one room")]
        public virtual void DeleteOneRoom()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete one room", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.Given("I delete the room \"3B\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.When("I execute the room delete action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "Code",
                            "Deleted"});
                table22.AddRow(new string[] {
                            "1A",
                            "False"});
                table22.AddRow(new string[] {
                            "2A",
                            "False"});
                table22.AddRow(new string[] {
                            "1B",
                            "False"});
                table22.AddRow(new string[] {
                            "2B",
                            "False"});
                table22.AddRow(new string[] {
                            "3B",
                            "True"});
#line 37
 testRunner.Then("the rooms deleted should be", ((string)(null)), table22, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Delete room with active reservations")]
        [Xunit.TraitAttribute("FeatureTitle", "DeleteRoom")]
        [Xunit.TraitAttribute("Description", "Delete room with active reservations")]
        public virtual void DeleteRoomWithActiveReservations()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete room with active reservations", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 45
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
#line 46
 testRunner.Given("I delete the room \"1A\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 47
 testRunner.When("I execute the room delete action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("I was told there are active reservations for this room", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                DeleteRoomFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DeleteRoomFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion