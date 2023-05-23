using AutomationFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages
{
    public class WishlistPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public WishlistPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public WishlistPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        public string GetItemName(string itemName)
        {
            return CommonMethods.ReadTextFromElement(
                 driver, By.LinkText(itemName));
        }
    }
}
