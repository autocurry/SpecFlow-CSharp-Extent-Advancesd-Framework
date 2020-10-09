using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SpecflowForExperion.Pages;
using SpecflowForExperion.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowForExperion.Steps
{
    [Binding]
    public sealed class NOPCommerceVerificationSteps
    {
        
        private readonly ScenarioContext _scenariocontext;

        public NOPCommerceVerificationSteps(ScenarioContext context)
        {
            this._scenariocontext = context;
        }

        IWebDriver _driver;
        private string emailResult;

        [Given(@": I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {

            _driver = (IWebDriver)_scenariocontext["driver"];
            _driver.Navigate().GoToUrl(getURL("login"));
        }

               

        [Given(@"I have access to the NOPCommerceWebsite")]
        public void GivenIHaveAccessToTheNOPCommerceWebsite()
        {            
            LoginPage _loginPage = new LoginPage(_driver);
            _loginPage.LoginToPortal();
        }

        [When(@"I navigate to the (.*) page")]
        public void WhenINavigateToTheAdminPage(string pageName)
        {
            _driver.Navigate().GoToUrl(getURL(pageName));           

        }

        [Then(@"Verify the All time pending order value is (.*)")]
        public void ThenVerifyTheAllTimePendingOrderValueIs(string alltimevalue)
        {
            AdminPage _adminPage = new AdminPage(_driver);
            Assert.AreEqual(alltimevalue, _adminPage.getALLTimePendingValue());

        }
        [When(@"Enter the first name (.*) and Search")]
        public void WhenEnterTheFirstNameAndSearch(string name)
        {
            CustomerPage _customerPage = new CustomerPage(_driver);
           emailResult =  _customerPage.getEmailUsingFirstName(name);
        }

        [Then(@"the Email id displayed will be (.*)")]
        public void ThenTheEmailIdDisplayedWillBeAdminYourStore_Com(string email)
        {

            Assert.AreEqual(emailResult, email);

        }
        private string getURL(string name)
        {
            switch (name.ToLower())
            {
                case "login":
                    return "https://admin-demo.nopcommerce.com/";
                    

                case "admin":
                    return "https://admin-demo.nopcommerce.com/Admin/";
                    

                case "customer":
                    return "https://admin-demo.nopcommerce.com/Admin/Customer/List/";

                default:
                    return "https://admin-demo.nopcommerce.com/";

            }
        }

    }
}
