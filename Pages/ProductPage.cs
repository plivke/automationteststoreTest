using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class ProductPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ProductPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ProductPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By addToCartButtonBy = By.PartialLinkText("Add to Cart");
        readonly By productNameBy = By.XPath("//span[@class='bgnone']");
        readonly By addToWishlistBy = By.XPath("//a[contains(@class, 'wishlist_add btn btn-large')]");
        readonly By removeFromWishlishBy = By.XPath("//a[contains(@class, 'wishlist_remove btn btn-large')]");

        /// <summary>
        /// Metoda koja klikne na Add to Cart dugme
        /// </summary>
        public void ClickOnAddToCart() { ClickElement(addToCartButtonBy); }

        /// <summary>
        /// Metoda koja vraca ime prvog proizvoda u korpi
        /// </summary>
        /// <returns>ime proizvoda</returns>
        public string GetProductName()
        {
            return ReadText(productNameBy);
        }

        /// <summary>
        /// Metoda koja klikne na add to wishlist dugme.
        /// Ako izabrani proizvod je vec u Wishlist-i, metoda izbacuje 
        /// proizvod iz Wishlist-e kako bi se opet ubacio
        /// </summary>
        public void ClickOnAddToWishlist()
        {
            if (!CommonMethods.IsElementPresented(_driver, addToWishlistBy))
            {
                ClickElement(removeFromWishlishBy);
            }
            ClickElement(addToWishlistBy);
        }

        /// <summary>
        /// Metoda koja klikne na remove from wishlist dugme.
        /// Ako izabrani proizvod nije u Wishlist-i, metoda ubacuje 
        /// proizvod u Wishlist-u kako be se opet izbacio
        /// </summary>
        public void ClickOnRemoveFromWishlist()
        {
            if (!CommonMethods.IsElementPresented(_driver, removeFromWishlishBy))
            {
                ClickElement(addToWishlistBy);
            }
            ClickElement(removeFromWishlishBy);
        }
    }
}