using Microsoft.SqlServer.Server;
using OpenQA.Selenium;
using SpecflowForExperion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowForExperion.Pages
{
    public class CustomerPage : BasePage
    {
       
        By FirstNameTextBox =By.Id("SearchFirstName");
        By SearchButton = By.Id("search-customers");
        By EmailIdValue = By.XPath("//*[@id='customers-grid']/tbody/tr/td[2]");

        public CustomerPage(IWebDriver driver):base(driver)
        {
            
        }

       public string getEmailUsingFirstName(string firstName)
        {
            EnterText(firstName,FirstNameTextBox);
            ClickButton(SearchButton);
            Thread.Sleep(2000);
           return getText(EmailIdValue);
        }

    }
}
