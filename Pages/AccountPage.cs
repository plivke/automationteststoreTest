using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class AccountPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By continueButtonBy = By.XPath("//button[@title='Continue']");
        By loginNameBy = By.Id("loginFrm_loginname");
        By loginPasswordBy = By.Id("loginFrm_password");
        By loginButtonBy = By.XPath("//button[@title='Login']");
        By forgottenPasswordBy = By.PartialLinkText("Forgot your password?");
        By forgottenLoginBy = By.PartialLinkText("Forgot your login?");
        By guestCheckoutBy = By.Id("accountFrm_accountguest");
        By wishlistLinkBy = By.XPath("//a[@data-original-title='My wish list']");

        /// <summary>
        /// Metoda koja klikne na Continue dugme za registraciju
        /// </summary>
        public void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja klikne na Login dugme
        /// </summary>
        private void ClickOnLogin() { ClickElement(loginButtonBy); }

        /// <summary>
        /// Metoda koja popunjava login name polje
        /// </summary>
        /// <param name="name">Username</param>
        private void EnterLoginName(string name) { WriteText(loginNameBy, name); }

        /// <summary>
        /// Metoda koja popunjava login password polje
        /// </summary>
        /// <param name="password">User password</param>
        private void EnterLoginPassword(string password) { WriteText(loginPasswordBy, password); }

        /// <summary>
        /// Metoda koja popunjava Login formu i loguje user-a
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        public void LoginUser(string username, string password)
        {
            EnterLoginName(username);
            EnterLoginPassword(password);
            ClickOnLogin();
        }

        /// <summary>
        /// Metoda koja vodi gosta na checkout
        /// </summary>
        public void GuestCheckout()
        {
            ClickElement(guestCheckoutBy);
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja klikne na Wishlist link
        /// </summary>
        public void ClickOnWishlistLink()
        {
            ClickElement(wishlistLinkBy);
        }

        /// <summary>
        ///Metoda koja klikne na link za izgubljeni password
        /// </summary>
        public void ClickOnForgottenPassword() { ClickElement(forgottenPasswordBy); }

        /// <summary>
        /// Metoda koja klikne na link za izgubljeni login
        /// </summary>
        public void ClickOnForgottenLogin() { ClickElement(forgottenLoginBy); }

    }
}
