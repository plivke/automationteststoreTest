using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class CartPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CartPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CartPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By totalsTableBy = By.XPath("//table[@id='totals_table']");
        By removeButtonBy = By.XPath("//i[contains(@class, 'fa-trash')]/..");
        By continueButtonBy = By.XPath("//a[@title='Continue']");
        By checkoutButtonBy = By.Id("cart_checkout1");

        /// <summary>
        /// Metoda koja proverava postojanje proizvoda u korpi
        /// </summary>
        /// <returns></returns>
        public bool IsCartNotEmpty()
        {
            Thread.Sleep(1000);
            return CommonMethods.IsElementPresented(driver, totalsTableBy);
        }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja izmesta sve proizvode iz korpe
        /// </summary>
        public void RemoveItemsFromCart()
        {
            while (IsCartNotEmpty())
            {
                ClickElement(removeButtonBy);
            }
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja klikne na checkout dugme
        /// </summary>
        public void ClickOnCheckout() { ClickElement(checkoutButtonBy); }
    }
}
