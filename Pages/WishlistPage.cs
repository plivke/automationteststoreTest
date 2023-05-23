using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

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
        /// Metoda koja vraca ime 
        /// </summary>
        /// <returns>Vraca ime proizvoda iz wishlist-e</returns>
        public string GetItemName()
        {
            return CommonMethods.ReadTextFromElement(driver, itemNameBy);
        }

        /// <summary>
        /// Metoda koja sklanja proizvod iz wishlist-e
        /// </summary>
        public void RemoveItem()
        {
            Thread.Sleep(1000);
            ClickElement(removeButtonBy);
        }

        /// <summary>
        /// Metoda koja proverava da li je wishlist-a prazna
        /// </summary>
        /// <returns>Vraca da li je item u wishlist-i</returns>
        public bool IsItemPresent()
        {
            return CommonMethods.IsElementPresented(driver, itemNameBy);
        }
    }
}
