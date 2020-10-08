using Microsoft.SqlServer.Server;
using OpenQA.Selenium;
using SpecflowForExperion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowForExperion.Pages
{
    public class AdminPage : BasePage
    {
       
        By AllTimePending = By.XPath("//*[@id='average-order-report-grid']/tbody/tr[1]/td[6]");
        

        public AdminPage(IWebDriver driver):base(driver)
        {
            
        }

        public string getALLTimePendingValue()
        {
            return getText(AllTimePending);
        }
    }
}
