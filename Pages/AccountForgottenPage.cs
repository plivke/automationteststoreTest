using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class AccountForgottenPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountForgottenPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountForgottenPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By loginNameBy = By.Id("forgottenFrm_loginname");
        readonly By lastNameBy = By.Id("forgottenFrm_lastname");
        readonly By emailBy = By.Id("forgottenFrm_email");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");
        readonly By successMessageBy = By.XPath("//div[contains(@class, 'alert-success')]");

        /// <summary>
        /// Metoda koja upisuje username u odgovarajuce polje
        /// </summary>
        /// <param name="loginName">Korisnici username</param>
        private void EnterLoginName(string loginName) { WriteText(loginNameBy, loginName); }

        /// <summary>
        /// Metoda koja upisuje prezime u odgovarajuce polje
        /// </summary>
        /// <param name="lastName">Korisnicko prezime</param>
        private void EnterLastName(string lastName) { WriteText(lastNameBy, lastName); }


        /// <summary>
        /// Metoda koja upisuje email u odgovarajuce polje
        /// </summary>
        /// <param name="email">Korisnicki email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja popunjava formu za izgubljenu sifru i 
        /// prosledjuje je klikom na Continue dugme
        /// </summary>
        /// <param name="loginName">Korisnicki username</param>
        /// <param name="email">Korisnicki email</param>
        public void ForgottenPasswordFillout(string loginName, string email)
        {
            EnterLoginName(loginName);
            EnterEmail(email);
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja popunjava formu za izgubljene kredencijale
        /// i prosledjuje je klikom na Continue dugme
        /// </summary>
        /// <param name="lastName">Korisnicko prezime</param>
        /// <param name="email">Korisnicki email</param>
        public void ForgottenLoginFillout(string lastName, string email)
        {
            EnterLastName(lastName);
            EnterEmail(email);
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja vraca poruku o uspehu registracije korisnika.
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>vraca poruku o uspehu</returns>
        public string GetSuccessMessage()
        {
            return ReadText(successMessageBy).Trim().ToLower();
        }
    }
}
