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
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");
        readonly By loginNameBy = By.Id("loginFrm_loginname");
        readonly By loginPasswordBy = By.Id("loginFrm_password");
        readonly By loginButtonBy = By.XPath("//button[@title='Login']");
        readonly By forgottenPasswordBy = By.PartialLinkText("Forgot your password?");
        readonly By forgottenLoginBy = By.PartialLinkText("Forgot your login?");
        readonly By guestCheckoutBy = By.Id("accountFrm_accountguest");
        readonly By wishlistLinkBy = By.XPath("//a[@data-original-title='My wish list']");

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
        /// <param name="name">Korisnicki username</param>
        private void EnterLoginName(string name) { WriteText(loginNameBy, name); }

        /// <summary>
        /// Metoda koja popunjava login password polje
        /// </summary>
        /// <param name="password">Korisnicka sifra</param>
        private void EnterLoginPassword(string password) { WriteText(loginPasswordBy, password); }

        /// <summary>
        /// Metoda koja popunjava Login formu i prijavljuje korisnika na nalog
        /// </summary>
        /// <param name="username">Korisnicki username</param>
        /// <param name="password">Korisnicka sifra</param>
        public void LoginUser(string username, string password)
        {
            EnterLoginName(username);
            EnterLoginPassword(password);
            ClickOnLogin();
        }

        /// <summary>
        /// Metoda koja vodi gosta na Checkout
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
        ///Metoda koja klikne na link za izgubljenu sifru
        /// </summary>
        public void ClickOnForgottenPassword() { ClickElement(forgottenPasswordBy); }

        /// <summary>
        /// Metoda koja klikne na link za izgubljene kredencijale
        /// </summary>
        public void ClickOnForgottenLogin() { ClickElement(forgottenLoginBy); }

    }
}
