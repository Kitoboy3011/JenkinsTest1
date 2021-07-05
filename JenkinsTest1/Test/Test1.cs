using JenkinsTest1.PageObject;
using JenkinsTest1.Utils;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.Test
{
    [TestFixture]
    class Test1
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        WebDriverUtils webDriverUtils = new WebDriverUtils();
        ChromeDriver Driver;

        [SetUp]
        public void SetUp()
        {
            logger.Info("Тестовый проект" + Assembly.GetCallingAssembly().GetName().Name);
            logger.Info("Тест-кейс " + TestContext.CurrentContext.Test.ClassName);
            Driver = webDriverUtils.InitDriver();
            Driver.Navigate().GoToUrl("https://santehnika-online.ru/");
        }
        [Test]
        public void TransitionToAllStocksPage()
        {
            logger.Info("Тест " + TestContext.CurrentContext.Test.Name);
            HomePage homePage = new HomePage(Driver);
            AllStocksPage allStocksPage = homePage.ClickOnAllStocksLink();
            Assert.IsTrue(allStocksPage.IsOpen());
        }
        [Test]
        public void TransitionToCatalogPage()
        {
            logger.Info("Тест " + TestContext.CurrentContext.Test.Name);
            HomePage homePage = new HomePage(Driver);
            CatalogPage catalogPage = homePage.ClickOnAllCategoriesLink();
            Assert.IsTrue(catalogPage.IsOpen());
        }
        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome == ResultState.Failure
            || TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                logger.Info("Тест не пройден" + TestContext.CurrentContext.Result.Message + "\n"
                + TestContext.CurrentContext.Result.StackTrace);
                ScreenshotCaster(Driver);
            }
            if(TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                ScreenshotCaster(Driver);
                logger.Info("Тест пройден успешно");
            }
            webDriverUtils.CloseDriver(Driver);
        }
        public void ScreenshotCaster(ChromeDriver Driver)
        {
            ITakesScreenshot ssDriver = Driver;
            Screenshot screenshot = ssDriver.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\isa4e\\source\\repos\\JenkinsTest1\\JenkinsTest1\\bin\\Debug\\logs\\" + TestContext.CurrentContext.Test.Name + ".jpg");
        }
    }
}
