using AutomationFramework.Utils;
using Microsoft.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.DOMSnapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        By itemNameBy = By.XPath("//tr[2]/td[2]");
        By removeButtonBy = By.XPath("//i[contains(@class, 'fa fa-trash-o fa-fw')][1]");

        /// <summary>
        /// 
        /// </summary>
        public string GetItemName()
        {
            return CommonMethods.ReadTextFromElement(driver, itemNameBy);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveItem()
        {
            Thread.Sleep(1000);
            ClickElement(removeButtonBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Vraca da li je item u wishlisti</returns>
        public bool IsItemPresent()
        {
            return CommonMethods.IsElementPresented(driver, itemNameBy);
        }
    }
}
