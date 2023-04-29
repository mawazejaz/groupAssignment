using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace FirstAzureAppTestProject
{
    public class CrossBrowserTest_by_SeleniumIntegration
    {
        private static String BASE_URL = "https://mawaz.azurewebsites.net/";
        private static int TIMEOUT = 30;
        private void PerformTask(IWebDriver driver)
        {
            //Set the implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT);
            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl(BASE_URL);
            driver.Quit();
        }
        public void OpenChrome()
        {
            IWebDriver driver = new ChromeDriver();
            PerformTask(driver);
        }
    }
}
