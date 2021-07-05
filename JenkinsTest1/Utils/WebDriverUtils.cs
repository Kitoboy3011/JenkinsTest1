using NLog;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.Utils
{
    class WebDriverUtils
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ChromeDriver InitDriver()
        {
            logger.Info("Инициализация драйвера");
            try
            {
                ChromeDriver Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                return Driver;
            }
            catch(Exception ex)
            {
                logger.Fatal(ex + " Не удалось инициализировать драйвер ");
                return null;
            }
        }
        public ChromeDriver CloseDriver(ChromeDriver Driver)
        {
            logger.Info("Закрытие подключения к драйверу");
            try
            {
                Driver.Close();
                return Driver;
            }
            catch(Exception ex)
            {
                logger.Fatal(ex + " Не удалось закрыть подключение к драйверу ");
                return null;
            }
        }
    }
}
