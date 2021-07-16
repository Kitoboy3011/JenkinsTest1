using Allure.Commons;
using JenkinsTest1.PageObject;
using JenkinsTest1.Utils;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
    [AllureNUnit]
    [AllureDisplayIgnored]
    class Test1
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        WebDriverUtils webDriverUtils = new WebDriverUtils();
        ChromeDriver Driver;

        [SetUp]
        public void SetUp()
        {
            logger.Info("Тест-кейс " + TestContext.CurrentContext.Test.ClassName);
            Driver = webDriverUtils.InitDriver();
            Driver.Navigate().GoToUrl("https://santehnika-online.ru/");
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void TransitionToAllStocksPage()
        {
            logger.Info("Тест " + TestContext.CurrentContext.Test.Name);
            HomePage homePage = new HomePage(Driver);
            AllStocksPage allStocksPage = homePage.ClickOnAllStocksLink();
            Assert.IsTrue(allStocksPage.IsOpen());
        }
        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
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
            string ScreenshotPath = AppDomain.CurrentDomain.BaseDirectory;
            screenshot.SaveAsFile(ScreenshotPath + "logs\\" + TestContext.CurrentContext.Test.Name + ".jpg");
        }
    }
}
