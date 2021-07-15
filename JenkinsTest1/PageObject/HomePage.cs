using JenkinsTest1.Utils;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.PageObject
{
    class HomePage : BasePageObject
    {
        private readonly ChromeDriver Driver;
        public HomePage(ChromeDriver driver)
        {
            this.Driver = driver;
        }

        private IWebElement AllStockLink => Driver.FindElement(By.XPath("/html/body/div[3]/main/div[2]/div/div[1]/a"));

        private IWebElement AllCategoriesLink => Driver.FindElement(By.XPath("/html/body/div[3]/main/div[5]/div/d"));

        public AllStocksPage ClickOnAllStocksLink()
        {
            logger.Info("Нажатие на ссылку Все скидки");
            AllStockLink.ClickOnElement();
            return new AllStocksPage(Driver);
        }
        public CatalogPage ClickOnAllCategoriesLink()
        {
            logger.Info("Нажатие на ссылку Все категории");
            AllCategoriesLink.ClickOnElement();
            return new CatalogPage(Driver);
        }
    }
}
