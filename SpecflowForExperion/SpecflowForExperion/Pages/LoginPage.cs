using OpenQA.Selenium;
using SpecflowForExperion.Utils;

/*
 - All controls from the nop commerce website - login page is available here.
- All reusability functions are provided here
*/


namespace SpecflowForExperion.Pages
{
    public class LoginPage : BasePage
    {

        By Email = By.Id("Email");
        By Password = By.Id("Password");
        By Login = By.XPath("//input[@type='submit']");

        public LoginPage(IWebDriver driver) : base(driver)
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
