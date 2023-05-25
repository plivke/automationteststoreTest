using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Linq;
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
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">_driver</param>
        public WishlistPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By itemNameBy = By.XPath("//div[@id = 'maincontainer']//tr[2]/td[2]/a");
        readonly By removeButtonBy = By.XPath("//i[contains(@class, 'fa fa-trash-o fa-fw')][1]");
        readonly By wishlistEmptyBy = By.ClassName("contentpanel");

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
                //Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Metoda koja vraca poruku o praznoj Wishlist-i.
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>vraca poruku o praznoj Wishlist-i</returns>
        public string GetWishlistEmptyMessage()
        {
            //Thread.Sleep(500);
            return ReadText(wishlistEmptyBy).Trim().ToLower();
        }

        /// <summary>
        /// Metoda koja proverava postoji li item u Wishlist-i
        /// </summary>
        /// <returns>vraca True ako je proizvod u Wishlist-i</returns>
        public bool IsItemPresent()
        {
            return CommonMethods.IsElementPresented(_driver, itemNameBy);
        }
    }
}
