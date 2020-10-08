using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowForExperion.Steps
{
    [Binding]
    public sealed class NOPCommerceVerificationSteps
    {
        IWebDriver driver; 

        [Given(@"I have access to the NOPCommerceWebsite")]
        public void GivenIHaveAccessToTheNOPCommerceWebsite()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://admin-demo.nopcommerce.com/");
            driver.Manage().Window.Maximize();

            var email = driver.FindElement(By.Id("Email"));
            email.Clear();
            email.SendKeys("admin@yourstore.com");

            var password = driver.FindElement(By.Id("Password"));
            password.Clear();
            password.SendKeys("admin");


            driver.FindElement(By.XPath("//input[@type='submit']")).Submit();
        }

        [When(@"I navigate to the (.*) page")]
        public void WhenINavigateToTheAdminPage(string pageName)
        {
            driver.Navigate().GoToUrl("https://admin-demo.nopcommerce.com/Admin/Customer/List");

            var pagename = driver.Url;
            Assert.IsTrue(pageName.Contains(pageName));

        }

        [Then(@"Verify the All time pending order value is (.*)")]
        public void ThenVerifyTheAllTimePendingOrderValueIs(string alltimevalue)
        {
            var element = driver.FindElement(By.XPath("//div[@id='order-average-report-box']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            var tables = driver.FindElements(By.XPath("//div[@id='order-average-report-box']//table"));
            var ALLTimePending = driver.FindElement(By.XPath("//*[@id='average-order-report-grid']/tbody/tr[1]/td[6]")).Text;

            Assert.AreEqual(alltimevalue, ALLTimePending);

        }
        [When(@"Enter the first name (.*) and Search")]
        public void WhenEnterTheFirstNameJohnAndSearch(string name)
        {
            var fname = driver.FindElement(By.Id("SearchFirstName"));
            fname.Clear();
            fname.SendKeys(name);

            driver.FindElement(By.Id("search-customers")).Click();
        }

        [Then(@"the Email id displayed will be (.*)")]
        public void ThenTheEmailIdDisplayedWillBeAdminYourStore_Com(string email)
        {
            Thread.Sleep(2000);
            var emailvalue = driver.FindElement(By.XPath("//*[@id='customers-grid']/tbody/tr/td[2]")).Text;
            Assert.AreEqual(emailvalue, email);

        }




    }
}
