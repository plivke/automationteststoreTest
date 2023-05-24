using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class AccountLogoutPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountLogoutPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountLogoutPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By logoutLinkBy = By.XPath("//ul[@class='info_links_footer']//a[contains(., 'Logoff')]");
        readonly By continueButtonBy = By.XPath("//a[@title='Continue']");


        /// <summary>
        /// Metoda koja vrsi odjavu korisnika i vracanje na index stranicu
        /// </summary>
        public void LogoutCustomer()
        {
            if (CommonMethods.IsElementPresented(_driver, logoutLinkBy))
                ClickElement(logoutLinkBy);
            ClickElement(continueButtonBy);
        }
    }
}