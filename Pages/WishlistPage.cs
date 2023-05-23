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
        /// <param name="webDriver">driver</param>
        public WishlistPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By itemNameBy = By.XPath("//tr[2]/td[2]/a");
        By removeButtonBy = By.XPath("//i[contains(@class, 'fa fa-trash-o fa-fw')][1]");

        /// <summary>
        /// Metoda koja vraca ime 
        /// </summary>
        /// <returns>ime proizvoda iz Wishlist-e</returns>
        public string GetItemName()
        {
            return ReadText(itemNameBy);
        }

        /// <summary>
        /// Metoda koja uklanja prvi proizvod iz Wishlist-e
        /// </summary>
        private void RemoveItemFromWishlist()
        {
            ClickElement(removeButtonBy);
        }

        /// <summary>
        /// Metoda koja uklanja sve proizvode iz Wishlist-e
        /// </summary>
        public void RemoveAllItemsFromWishlist()
        {
            while (IsItemPresent())
            {
                RemoveItemFromWishlist();
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Metoda koja proverava postoji li item u Wishlist-i
        /// </summary>
        /// <returns>vraca True ako je proizvod u Wishlist-i</returns>
        public bool IsItemPresent()
        {
            return CommonMethods.IsElementPresented(driver, itemNameBy);
        }
    }
}
