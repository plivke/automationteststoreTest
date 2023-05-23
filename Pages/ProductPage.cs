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
        By AddToWishlistBy = By.XPath("//a[contains(@class, 'wishlist_add btn btn-large')]");
        By removeFromWishlishBy = By.XPath("//a[contains(@class, 'wishlist_remove btn btn-large')]");

        public void ClickOnAddToCart() { ClickElement(addToCartButtonBy); }

        public string GetProductName()
        {
            Thread.Sleep(200);
            return CommonMethods.ReadTextFromElement(
                driver, productNameBy).Trim().ToLower();
        }

        /// <summary>
        /// Metoda koja klikne na add to wishlist dugme
        /// </summary>
        public void AddToWishlist()
        {
            ClickElement(AddToWishlistBy);
        }

        /// <summary>
        /// Metoda koja klikne na remove from wishlist dugme
        /// </summary>
        public void RemoveFromWishlist()
        {
            Thread.Sleep(1000);
            ClickElement(removeFromWishlishBy);
        }
    }
}