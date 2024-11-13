﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Kyiv.Tests
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ОпераціяДодаванняFeature : object, Xunit.IClassFixture<ОпераціяДодаванняFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("uk"), "", "Операція додавання", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Додавання.feature"
#line hidden
        
        public ОпераціяДодаванняFeature(ОпераціяДодаванняFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Звичайне додавання")]
        [Xunit.TraitAttribute("FeatureTitle", "Операція додавання")]
        [Xunit.TraitAttribute("Description", "Звичайне додавання")]
        public async System.Threading.Tasks.Task ЗвичайнеДодавання()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Звичайне додавання", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 5
  await testRunner.GivenAsync("пам\'ять заповнена значенями 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "Дано ");
#line hidden
#line 6
  await testRunner.AndAsync("ячейка 5 містить 100", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 7
  await testRunner.AndAsync("ячейка 18 містить 300", ((string)(null)), ((global::Reqnroll.Table)(null)), "А також ");
#line hidden
#line 8
  await testRunner.AndAsync("ячейка 100 містить команду \'01 0005 0022 0002\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 9
  await testRunner.AndAsync("регістр лічільник команд містить 100", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 10
  await testRunner.WhenAsync("виконати команді", ((string)(null)), ((global::Reqnroll.Table)(null)), "Якщо ");
#line hidden
#line 11
  await testRunner.ThenAsync("ячейка 2 містить 400", ((string)(null)), ((global::Reqnroll.Table)(null)), "Тоді ");
#line hidden
#line 12
  await testRunner.AndAsync("лічільник команд містить 101", ((string)(null)), ((global::Reqnroll.Table)(null)), "А також ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Додавання із переповненням")]
        [Xunit.TraitAttribute("FeatureTitle", "Операція додавання")]
        [Xunit.TraitAttribute("Description", "Додавання із переповненням")]
        public async System.Threading.Tasks.Task ДодаванняІзПереповненням()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Додавання із переповненням", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 15
  await testRunner.GivenAsync("пам\'ять заповнена значенями 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "Дано ");
#line hidden
#line 16
  await testRunner.AndAsync("ячейка 5 містить максимальне позітивне число", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 17
  await testRunner.AndAsync("ячейка 18 містить максимальне позітивне число", ((string)(null)), ((global::Reqnroll.Table)(null)), "А також ");
#line hidden
#line 18
  await testRunner.AndAsync("ячейка 100 містить команду \'01 0005 0022 0002\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 19
  await testRunner.AndAsync("регістр лічільник команд містить 100", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 20
  await testRunner.WhenAsync("виконати команді", ((string)(null)), ((global::Reqnroll.Table)(null)), "Якщо ");
#line hidden
#line 21
  await testRunner.ThenAsync("лічільник команд містить 102", ((string)(null)), ((global::Reqnroll.Table)(null)), "Тоді ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Додавання із переповненням і аварійною зупинкою")]
        [Xunit.TraitAttribute("FeatureTitle", "Операція додавання")]
        [Xunit.TraitAttribute("Description", "Додавання із переповненням і аварійною зупинкою")]
        public async System.Threading.Tasks.Task ДодаванняІзПереповненнямІАварійноюЗупинкою()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Додавання із переповненням і аварійною зупинкою", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 23
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 24
  await testRunner.GivenAsync("пам\'ять заповнена значенями 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "Дано ");
#line hidden
#line 25
  await testRunner.AndAsync("ячейка 5 містить максимальне позітивне число", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 26
  await testRunner.AndAsync("ячейка 18 містить максимальне позітивне число", ((string)(null)), ((global::Reqnroll.Table)(null)), "А також ");
#line hidden
#line 27
  await testRunner.AndAsync("ячейка 100 містить команду \'01 0005 0022 0002\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 28
  await testRunner.AndAsync("регістр лічільник команд містить 100", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 29
  await testRunner.AndAsync("аварійна зупинка включена", ((string)(null)), ((global::Reqnroll.Table)(null)), "І ");
#line hidden
#line 30
  await testRunner.WhenAsync("виконати команді", ((string)(null)), ((global::Reqnroll.Table)(null)), "Якщо ");
#line hidden
#line 31
  await testRunner.ThenAsync("лічільник команд містить 102", ((string)(null)), ((global::Reqnroll.Table)(null)), "Тоді ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await ОпераціяДодаванняFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await ОпераціяДодаванняFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
