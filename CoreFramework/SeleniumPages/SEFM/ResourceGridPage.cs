using OpenQA.Selenium;

namespace CoreFramework.SeleniumPages.SEFM
{
    public class ResourceGridPage : BasePage
    {
        public IWebElement ScenarioHeader => driver.FindElement(By.CssSelector("ui-components-breadcrumbs>div>div:nth-child(2)>span:nth-child(1)"));

        public ResourceGridPage(IWebDriver driver) : base(driver) { }
    }
}
