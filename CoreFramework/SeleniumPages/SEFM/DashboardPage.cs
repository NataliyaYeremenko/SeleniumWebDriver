using OpenQA.Selenium;

namespace CoreFramework.SeleniumPages.SEFM
{
    public class DashboardPage : BasePage
    {
        public IWebElement SettingsGear => driver.FindElement(By.XPath("//*[@class='icon-btn icon-settings font-size-28']"));
        public IWebElement FiltersResetButton => driver.FindElement(By.XPath("//*[@class='k-button']"));
        public IWebElement FiltersApplyButton => driver.FindElement(By.XPath("//*[@class='k-button k-primary']"));
        public IWebElement SelectWBSLevel1 => driver.FindElement(By.XPath("//*[@title='WBS Level 1 Column Menu']"));
        public IWebElement FilterWBSLevel1 => driver.FindElement(By.CssSelector("kendo-grid-string-filter-menu-input:nth-of-type(1) input"));
        public IWebElement DashboardGrid => driver.FindElement(By.XPath("//*[@class='d-flex flex-column overflow-hidden w-100']"));
        public IWebElement FilterSubmitWBSLevel1 => driver.FindElement(By.XPath("//*[@class='k-button k-button-solid-primary k-button-solid k-button-md k-rounded-md k-button-rectangle']"));
        public IWebElement OpenResourceGrid => driver.FindElement(By.XPath("//*[@class='k-column-action-buttons d-flex justify-content-around ng-star-inserted']/button[1]"));


        public void SelectFilterInSettingsGear(string filterName)
        {
            var checkbox = driver.FindElement(By.XPath($"//*[@class='k-checkbox-label'][text()='{filterName}']/../input"));
            checkbox.Click();
        }



        public DashboardPage(IWebDriver driver) : base(driver){}
    }
}
