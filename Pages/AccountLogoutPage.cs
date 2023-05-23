using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class AccountLogoutPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountLogoutPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountLogoutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By logoutLinkBy = By.XPath("//ul[@class='info_links_footer']//a[contains(., 'Logoff')]");
        By continueButtonBy = By.XPath("//a[@title='Continue']");
        

        /// <summary>
        /// Metoda koja odjavljuje korisnika i vraca ga na home page
        /// </summary>
        public void LogoutCustomer()
        {
            Thread.Sleep(200);
            if(CommonMethods.IsElementPresented(driver, logoutLinkBy))
            {
                ClickElement(logoutLinkBy);
                Thread.Sleep(1000);
                ClickElement(continueButtonBy);
            }
        }
    }
}