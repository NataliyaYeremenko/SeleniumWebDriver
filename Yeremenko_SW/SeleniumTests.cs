using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CoreFramework.SeleniumPages.SEFM;
using CoreFramework.Utils;

namespace Yeremenko_SW
{
    public class SeleniumTests : BaseTest
    {
        private const string _userName = "USITSDASBPM195@deloitte.com";
        private const string _userPassword = "qOg3R7BxtU663dN5E";

        [Test]
        public void TestMethod1()
        {
            
            driver.Url = "https://sefm.deloitte.com/engagements";
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login.SendKeys(_userName);
            loginPage.Next.Click();
            Thread.Sleep(1000);
            loginPage.PasswordInput.SendKeys(_userPassword);
            loginPage.SubmitButton.Click();
            Thread.Sleep(3000);
            DashboardPage dashboardPage = new DashboardPage(driver);
            var startWindowHandle = driver.CurrentWindowHandle;
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", dashboardPage.SettingsGear);
            Thread.Sleep(5000);
            dashboardPage.SettingsGear.Click();
            dashboardPage.FiltersResetButton.Click();
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", dashboardPage.SettingsGear);
            dashboardPage.SettingsGear.Click();
            dashboardPage.SelectFilterInSettingsGear("Select All");
            dashboardPage.SelectFilterInSettingsGear("Select All");
            dashboardPage.SelectFilterInSettingsGear("Approval Pending");
            dashboardPage.SelectFilterInSettingsGear("Approver");
            dashboardPage.SelectFilterInSettingsGear("Business");
            dashboardPage.SelectFilterInSettingsGear("Contract Type");
            dashboardPage.SelectFilterInSettingsGear("Current EAC Status");
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", dashboardPage.FiltersApplyButton);
            dashboardPage.FiltersApplyButton.Click();
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", dashboardPage.DashboardGrid);
            dashboardPage.SelectWBSLevel1.Click();
            dashboardPage.FilterWBSLevel1.Clear();
            dashboardPage.FilterWBSLevel1.SendKeys("AME02239-01");
            dashboardPage.FilterSubmitWBSLevel1.Click();
            Thread.Sleep(3000);
            dashboardPage.OpenResourceGrid.Click();
            
            //foreach (var handle in driver.WindowHandles)
            //    {
            //        if (handle != startWindowHandle) driver.SwitchTo().Window(handle);
            //    }
            ResourceGridPage resourceGridPage = new ResourceGridPage(driver);
            Thread.Sleep(7000);
            string expectedScenarioHeader = " AME02239-01, T&M RBR Contract ";
            Console.WriteLine(resourceGridPage.ScenarioHeader.GetAttribute("textContent"));
            Assert.True(resourceGridPage.ScenarioHeader.GetAttribute("textContent") == expectedScenarioHeader,
                $"Expected scenario header '{expectedScenarioHeader}' " +
                $"isn't matched acrual scenario header '{resourceGridPage.ScenarioHeader.GetAttribute("textContent")}'");
        }
        [Test]
        public void TestMethod2()
        {
            DBHelpers dBHelpers = new DBHelpers();
            dBHelpers.ReadData("select * from Engagement where WBSNumber like 'GOO009%';");
            Assert.True(true); 
        }
        
        [SetUp]
        public void BeforeTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void AfterTests()
        {
            driver.Quit();
        }

    }
}
