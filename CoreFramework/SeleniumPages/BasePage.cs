using OpenQA.Selenium;

namespace CoreFramework.SeleniumPages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
