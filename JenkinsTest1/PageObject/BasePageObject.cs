using JenkinsTest1.Utils;
using NLog;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.PageObject
{
    class BasePageObject
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        public ChromeDriver driver;
        static WebDriverUtils webDriverUtils = new WebDriverUtils();
        public bool CheckElementLoad = false;

        public BasePageObject()
        {
        }
    }
}
