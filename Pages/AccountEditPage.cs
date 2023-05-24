using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class AccountEditPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountEditPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountEditPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By firstNameBy = By.Id("AccountFrm_firstname");
        readonly By lastNameBy = By.Id("AccountFrm_lastname");
        readonly By emailBy = By.Id("AccountFrm_email");
        readonly By telephoneBy = By.Id("AccountFrm_telephone");
        readonly By faxBy = By.Id("AccountFrm_fax");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja menja ime korisnika
        /// </summary>
        /// <param name="firstName">Ime</param>
        private void EnterFirstName(string firstName)
        {
            WriteText(firstNameBy, firstName);
        }

        /// <summary>
        /// Metoda koja menja prezime korisnika
        /// </summary>
        /// <param name="lastName">Prezime</param>
        private void EnterLastName(string lastName)
        {
            WriteText(lastNameBy, lastName);
        }

        /// <summary>
        /// Metoda koja menja email korisnika
        /// </summary>
        /// <param name="email">Korisnicki email</param>
        private void EnterEmail(string email)
        {
            WriteText(emailBy, email);
        }

        /// <summary>
        /// Metoda koja menja broj telefona korisnika
        /// </summary>
        /// <param name="telephone">Broj telefona</param>
        private void EnterTelephone(string telephone)
        {
            WriteText(telephoneBy, telephone);
        }

        /// <summary>
        /// Metoda koja menja broj faksa korisnika
        /// </summary>
        /// <param name="fax">Broj faksa</param>
        private void EnterFax(string fax)
        {
            WriteText(faxBy, fax);
        }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        public void ClickOnCountinue()
        {
            ClickElement(continueButtonBy);
        }


    }
}
