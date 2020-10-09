using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

/*
 - Extension functions and reusuable codes are available here
- All reusability functions are provided here
*/


namespace SpecflowForExperion.Utils
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void EnterText(string text, By locator)
        {
            IWebElement element = WaitForElementExists(locator);
            element.Clear();
            element.SendKeys(text);

        }

        public void ClickButton(By locator)
        {
            WaitForElementExists(locator).Click();
        }

        public string getText(By locator)
        {
            return WaitForElementExists(locator).Text;
        }

        public void ScrollToElement(By locator)
        {
            var element = WaitForElementExists(locator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        private IWebElement WaitForElementExists(By element)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));


        }
    }
}
