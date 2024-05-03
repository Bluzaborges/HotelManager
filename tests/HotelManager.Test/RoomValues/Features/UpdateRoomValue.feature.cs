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
namespace HotelManager.Test.RoomValues.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "RoomValue")]
    public partial class UpdateRoomValueFeature : object, Xunit.IClassFixture<UpdateRoomValueFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "RoomValue"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UpdateRoomValue.feature"
#line hidden
        
        public UpdateRoomValueFeature(UpdateRoomValueFeature.FixtureData fixtureData, HotelManager_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RoomValues/Features", "UpdateRoomValue", "\tIn order to change the value of a room value\r\n\tAs a admin\r\n\tI want to update the" +
                    " room value", ProgrammingLanguage.CSharp, new string[] {
                        "RoomValue"});
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
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Type",
                        "Name",
                        "Value"});
            table31.AddRow(new string[] {
                        "1",
                        "Deluxe",
                        "Luxo",
                        "150.00"});
            table31.AddRow(new string[] {
                        "2",
                        "Conventional",
                        "Convencional",
                        "98.00"});
#line 8
 testRunner.Given("these room values", ((string)(null)), table31, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "Code",
                        "RoomValue",
                        "Deleted"});
            table32.AddRow(new string[] {
                        "1A",
                        "1",
                        "False"});
            table32.AddRow(new string[] {
                        "2A",
                        "1",
                        "True"});
            table32.AddRow(new string[] {
                        "1B",
                        "2",
                        "False"});
            table32.AddRow(new string[] {
                        "2B",
                        "2",
                        "False"});
            table32.AddRow(new string[] {
                        "3B",
                        "2",
                        "True"});
#line 12
 testRunner.And("these rooms", ((string)(null)), table32, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Update room value")]
        [Xunit.TraitAttribute("FeatureTitle", "UpdateRoomValue")]
        [Xunit.TraitAttribute("Description", "Update room value")]
        public virtual void UpdateRoomValue()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update room value", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 20
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
#line 21
 testRunner.Given("I update the value of the \"Conventional\" room value to 110.35", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.And("the name to \"Exclusivo\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.When("I update the room value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Number",
                            "Value"});
                table33.AddRow(new string[] {
                            "1",
                            "150.00"});
                table33.AddRow(new string[] {
                            "2",
                            "110.35"});
#line 24
 testRunner.Then("the room values should be", ((string)(null)), table33, "Then ");
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
                UpdateRoomValueFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UpdateRoomValueFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
