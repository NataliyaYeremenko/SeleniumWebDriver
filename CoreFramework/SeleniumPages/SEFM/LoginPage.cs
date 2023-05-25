using OpenQA.Selenium;

namespace CoreFramework.SeleniumPages.SEFM
{
    public class LoginPage : BasePage
    {
        public IWebElement Login => driver.FindElement(By.Id("i0116"));
        public IWebElement Next => driver.FindElement(By.Id("idSIButton9"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("passwordInput"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submitButton"));
        public LoginPage(IWebDriver driver) : base(driver){}
    }
}
