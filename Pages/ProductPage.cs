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

        public void ClickOnAddToCart() { ClickElement(addToCartButtonBy); }

        public string GetProductName()
        {
            Thread.Sleep(200);
            return CommonMethods.ReadTextFromElement(
                driver, productNameBy).Trim().ToLower();
        }
    }
}