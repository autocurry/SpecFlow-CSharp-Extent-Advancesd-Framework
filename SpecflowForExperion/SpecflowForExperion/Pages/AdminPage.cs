using OpenQA.Selenium;
using SpecflowForExperion.Utils;

/*
 - All controls from the nop commerce website - admin page is available here.
- All reusability functions are provided here
*/


namespace SpecflowForExperion.Pages
{
    public class AdminPage : BasePage
    {

        By AllTimePending = By.XPath("//*[@id='average-order-report-grid']/tbody/tr[1]/td[6]");


        public AdminPage(IWebDriver driver) : base(driver)
        {

        }

        public string getALLTimePendingValue()
        {
            return getText(AllTimePending);
        }
    }
}
