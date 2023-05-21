using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class CheckoutPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CheckoutPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CheckoutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By currencyListBy = By.XPath("//div[@class='block_6']");
        By checkoutButtonBy = By.Id("checkout_btn");
        By orderProcessedMessageBy = By.XPath("//span[@class='maintext']");

        /// <summary>
        /// Metoda koja postavlja valutu
        /// </summary>
        /// <param name="CUR">Curencies: EUR, USD or GBP</param>
        public void SetCurrency(string CUR)
        {
            ClickElement(currencyListBy);
            Thread.Sleep(100);
            ClickElement(By.XPath($"//div[@class='block_6']//a[contains(@href, '{CUR}')]"));
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClickOnConfirmOrder() { ClickElement(checkoutButtonBy); }

        /// <summary>
        /// Metoda koja zavrsava kupovinu u zeljenoj valuti
        /// </summary>
        /// <param name="CUR">Curencies: EUR, USD or GBP</param>
        public void PurchaseInCurency(string CUR)
        {
            SetCurrency(CUR);
            Thread.Sleep(100);
            ClickOnConfirmOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetSuccessMessage()
        {
            Thread.Sleep(500);
            return CommonMethods.ReadTextFromElement(
                driver, orderProcessedMessageBy).Trim().ToLower();
        }
    }
}
