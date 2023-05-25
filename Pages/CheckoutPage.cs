using AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationFramework.Pages
{
    public class CheckoutPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public CheckoutPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public CheckoutPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By currencyListBy = By.XPath("//div[@class='block_6']");
        readonly By checkoutButtonBy = By.Id("checkout_btn");
        readonly By orderProcessedMessageBy = By.XPath("//span[@class='maintext']");
        readonly By editShippingButtonBy = By.XPath("//a[contains(.,'Edit Shipping')]");
        readonly By checkoutConfirmationTitleBy = By.XPath("//span[contains(@class, 'maintext')]");
        readonly By continueButtonBy = By.XPath("//a[@title='Continue']");

        /// <summary>
        /// Metoda koja postavlja valutu
        /// </summary>
        /// <param name="CUR">Curencies: EUR, USD or GBP</param>
        public void SetCurrency(string CUR)
        {
            CommonMethods.HoverOnElement(_driver, currencyListBy);
            ClickElement(By.XPath($"//div[@class='block_6']//a[contains(@href, '{CUR}')]"));
        }

        /// <summary>
        /// Metoda koja klikne na Confirm Order dugme
        /// </summary>
        private void ClickOnConfirmOrder() { ClickElement(checkoutButtonBy); }

        /// <summary>
        /// Metoda koja zavrsava kupovinu u zeljenoj valuti
        /// </summary>
        /// <param name="CUR">Curencies: EUR, USD or GBP</param>
        public void PurchaseInCurency(string CUR)
        {
            SetCurrency(CUR);
            ClickOnConfirmOrder();
        }

        /// <summary>
        /// Metoda koja vraca poruku o uspehu procesiranja porudzbine.
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>poruku o uspesnoj porudzbini</returns>
        public string GetSuccessMessage()
        {
            _wait = new(_driver, TimeSpan.FromMilliseconds(2000));
            _wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            _wait.Until(ExpectedConditions.ElementExists(continueButtonBy));
            return ReadText(orderProcessedMessageBy).Trim().ToLower();
        }

        public void ClickOnEditShippingButton()
        {
            ClickElement(editShippingButtonBy);
        }

        public bool IsItemPresent()
        {
            return CommonMethods.IsElementPresented(_driver, checkoutConfirmationTitleBy);
        }
    }
}
