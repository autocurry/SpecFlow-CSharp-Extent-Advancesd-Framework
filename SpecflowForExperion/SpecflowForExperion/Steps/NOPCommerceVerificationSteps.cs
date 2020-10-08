using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowForExperion.Steps
{
    [Binding]
    public sealed class NOPCommerceVerificationSteps
    {
        [Given(@"I have access to the NOPCommerceWebsite")]
        public void GivenIHaveAccessToTheNOPCommerceWebsite()
        {
            
        }

        [When(@"I navigate to the (.*) page")]
        public void WhenINavigateToTheAdminPage(string pageName)
        {
            
        }

        [Then(@"Verify the All time pending order value is (.*)")]
        public void ThenVerifyTheAllTimePendingOrderValueIs(double alltimevalue)
        {
            
        }

    }
}
