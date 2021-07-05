using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest1.Utils
{
    public static class IWebElementExtension
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static IWebElement ClickOnElement(this IWebElement element)
        {
            try
            {
                element.Click();
                return element;
            }
            catch(Exception ex)
            {
                logger.Fatal(ex + " Элемент " + element + " не найден ");
                return null;
            }
        }
    }
}
