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
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CartPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By totalsTableBy = By.XPath("//table[@id='totals_table']");
        readonly By removeButtonBy = By.XPath("//i[contains(@class, 'fa-trash')]/..");
        readonly By continueButtonBy = By.XPath("//a[@title='Continue']");
        readonly By checkoutButtonBy = By.Id("cart_checkout1");

        /// <summary>
        /// Metoda koja proverava postojanje proizvoda u korpi
        /// </summary>
        /// <returns>true = korpa nije prazna || false = korpa je prazna</returns>
        public bool IsCartNotEmpty()
        {
            Thread.Sleep(200);
            return CommonMethods.IsElementPresented(_driver, totalsTableBy);
        }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja izmesta sve proizvode iz korpe i izlazi iz nje
        /// klikom na Continue dugme
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
