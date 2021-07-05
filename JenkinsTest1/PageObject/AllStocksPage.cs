using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.PageObject
{
    class AllStocksPage : BasePageObject
    {
        private readonly ChromeDriver Driver;
        public AllStocksPage(ChromeDriver driver)
        {
            this.Driver = driver;
        }
        private IWebElement StocksLabel => Driver.FindElement(By.CssSelector("h1[class='b-title b-title--h1']"));

        public bool IsOpen()
        {
            try
            {
                return Wait(StocksLabel);
            }
            catch (Exception ex)
            {
                logger.Fatal(ex + " Страница не загружена или отобразилась не верно");
                return false;
            }
        }
        public bool Wait(IWebElement element)
        {
            logger.Info("Ожидание элемента на странице");
            try
            {
                logger.Info("Элемент найден");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                return wait.Until(Driver => element.Enabled);
            }
            catch (Exception ex)
            {
                logger.Fatal(ex +" Элемент" + element + " не найден ");
                return false;
            }
        }
    }
}
