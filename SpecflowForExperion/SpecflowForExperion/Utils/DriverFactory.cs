using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace SpecflowForExperion.Utils
{
    public class DriverFactory
    {


        public IWebDriver driver;

        public IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");
                    return new ChromeDriver(options);

                case "ie":
                    return new InternetExplorerDriver();

                case "firefox":
                    return new FirefoxDriver();

                default:
                    return new ChromeDriver();

            }

        }


    }
}
