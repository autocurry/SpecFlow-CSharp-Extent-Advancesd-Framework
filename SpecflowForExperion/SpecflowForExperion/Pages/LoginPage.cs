using OpenQA.Selenium;
using SpecflowForExperion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowForExperion.Pages
{
    public class LoginPage : BasePage
    {
       
        By Email = By.Id("Email");
        By Password = By.Id("Password");
        By Login = By.XPath("//input[@type='submit']");

        public LoginPage(IWebDriver driver):base(driver)
        {
            
        }

        public void LoginToPortal()
        {
            EnterText("admin@yourstore.com", Email);
            EnterText("admin", Password);
            ClickButton(Login);
        }

    }
}
