using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowForExperion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowForExperion.Hooks
{
    [Binding]
    public sealed class NOPCommerceHooks
    {
        private readonly ScenarioContext _scenariocontext;

        public NOPCommerceHooks(ScenarioContext context)
        {
            this._scenariocontext = context;
        }


        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var webDriver = new DriverFactory().CreateDriver("");
            _scenariocontext["driver"] = webDriver;  
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
           var driver =  (IWebDriver)_scenariocontext["driver"];
            driver.Quit();
        }
    }
}
