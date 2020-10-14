using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecflowForExperion.Utils;
using System.Linq;
using TechTalk.SpecFlow;


/* 
 Hooks class is for resuablity of the code.  
 */


namespace SpecflowForExperion.Hooks
{
    [Binding]
    public sealed class NOPCommerceHooks
    {
        private readonly ScenarioContext _scenariocontext;
        static ExtentReports _extent;
        static ExtentTest featureName;
        static ExtentTest scenarioName;
        const string path = @"C:\temp\NOPCommerce\";

        public NOPCommerceHooks(ScenarioContext context)
        {
            this._scenariocontext = context;
        }


        /*
         - Runs before the complete test execution
          - Creates an instance of the extent reporter
         */

        [BeforeTestRun]
        public static void IntiatizeTestRun()
        {

            var reportPath = path + "ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

        }

        /*
         - Runs after the complete test execution
          - Kills and flushes the extent reporter instance
         */

        [AfterTestRun]
        public static void TearDownExecution()
        {
            _extent.Flush();
        }

        /*
         - Runs before every feature 
          - This inserts a feature instance into the extent report
         */

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = _extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
        }



        [AfterFeature]
        public static void AfterFeature()
        {

        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            scenarioName = featureName.CreateNode<Scenario>(_scenariocontext.ScenarioInfo.Title);

            var browserTags = _scenariocontext.ScenarioInfo.Tags.Where(x => x.Contains("browser"));
            var browserName = browserTags.FirstOrDefault().Substring(8);

            var webDriver = new DriverFactory().CreateDriver(browserName);
            _scenariocontext["driver"] = webDriver;
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            var driver = (IWebDriver)_scenariocontext["driver"];
            driver.Quit();
        }

        [AfterStep]
        public void AfterEachScenarioStep()
        {
            var driver = (IWebDriver)_scenariocontext["driver"];

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenariocontext.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }

            }
            else if (_scenariocontext.TestError != null)
            {


                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenariocontext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenariocontext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenariocontext.TestError.Message);

                }
                else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenariocontext.TestError.Message);
                }
                AttachScreenshot(scenarioName, driver, ScenarioStepContext.Current.StepInfo.Text);

            }

        }

        private void AttachScreenshot(ExtentTest scenarioName, IWebDriver driver, string stepInfo)
        {
            string screenshotpath = path + "Screenshots\\" + stepInfo.Replace(" ", "_").Substring(0, 25) + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotpath, ScreenshotImageFormat.Png);
            scenarioName.AddScreenCaptureFromPath(screenshotpath);
        }
    }
}
