using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowForExperion.Utils
{
    public class DriverFactory
    {


        public IWebDriver driver;

        public IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToUpper())
            {
                case "chrome":
                    return new ChromeDriver();
                    break;
                default:
                    return new ChromeDriver();
                    break;
            }



        }


    }
}
