using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class ProductPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ProductPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ProductPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By addToCartButtonBy = By.PartialLinkText("Add to Cart");
        By productNameBy = By.XPath("//span[@class='bgnone']");
        By addToWishlistBy = By.XPath("//a[contains(@class, 'wishlist_add btn btn-large')]");
        By removeFromWishlishBy = By.XPath("//a[contains(@class, 'wishlist_remove btn btn-large')]");

        /// <summary>
        /// Metoda koja klikne na Add to Cart dugme
        /// </summary>
        public void ClickOnAddToCart() { ClickElement(addToCartButtonBy); }

        /// <summary>
        /// Metoda koja vraca ime proizvoda
        /// </summary>
        /// <returns>Vraca ime proizvoda</returns>
        public string GetProductName()
        {
            return ReadText(productNameBy).Trim().ToLower();
        }

        /// <summary>
        /// Metoda koja klikne na add to wishlist dugme
        /// </summary>
        public void ClickOnAddToWishlist()
        {
            if (!CommonMethods.IsElementPresented(driver, addToWishlistBy))
            {
                ClickElement(removeFromWishlishBy);
            }
            Thread.Sleep(500);
            ClickElement(addToWishlistBy);
        }

        /// <summary>
        /// Metoda koja klikne na remove from wishlist dugme
        /// </summary>
        public void ClickOnRemoveFromWishlist()
        {
            if (!CommonMethods.IsElementPresented(driver, removeFromWishlishBy))
            {
                ClickElement(addToWishlistBy);
            }
            Thread.Sleep(500);
            ClickElement(removeFromWishlishBy);
        }
    }
}