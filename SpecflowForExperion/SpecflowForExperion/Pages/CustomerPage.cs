using OpenQA.Selenium;
using SpecflowForExperion.Utils;
using System.Threading;

/*
 - All controls from the nop commerce website - customer page is available here.
- All reusability functions are provided here
*/

namespace SpecflowForExperion.Pages
{
    public class CustomerPage : BasePage
    {

        By FirstNameTextBox = By.Id("SearchFirstName");
        By SearchButton = By.Id("search-customers");
        By EmailIdValue = By.XPath("//*[@id='customers-grid']/tbody/tr/td[2]");

        public CustomerPage(IWebDriver driver) : base(driver)
        {

        }

        public string getEmailUsingFirstName(string firstName)
        {
            EnterText(firstName, FirstNameTextBox);
            ClickButton(SearchButton);
            Thread.Sleep(2000);
            return getText(EmailIdValue);
        }

    }
}
