using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Pages
{
    public class AccountCreatePage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountCreatePage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountCreatePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By firstNameBy = By.Id("AccountFrm_firstname");
        readonly By lastNameBy = By.Id("AccountFrm_lastname");
        readonly By emailBy = By.Id("AccountFrm_email");
        readonly By telephoneBy = By.Id("AccountFrm_telephone");
        readonly By faxBy = By.Id("AccountFrm_fax");
        readonly By companyBy = By.Id("AccountFrm_company");
        readonly By address1By = By.Id("AccountFrm_address_1");
        readonly By address2By = By.Id("AccountFrm_address_2");
        readonly By cityBy = By.Id("AccountFrm_city");
        readonly By regionStateBy = By.Id("AccountFrm_zone_id");
        readonly By regionStateOptionsBy = By.XPath("//select[@id='AccountFrm_zone_id']/option");
        readonly By zipCodeBy = By.Id("AccountFrm_postcode");
        readonly By countryBy = By.Id("AccountFrm_country_id");
        readonly By countryOptionsBy = By.XPath("select[@id='AccountFrm_country_id']/option");
        readonly By loginNameBy = By.Id("AccountFrm_loginname");
        readonly By passwordBy = By.Id("AccountFrm_password");
        readonly By passwordConfirmBy = By.Id("AccountFrm_confirm");
        readonly By newsletterYesBy = By.Id("AccountFrm_newsletter1");
        readonly By newsletterNoBy = By.Id("AccountFrm_newsletter0");
        readonly By privacyPolicyBy = By.Id("AccountFrm_agree");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");
        readonly By registationSuccessBy = By.XPath("//span[@class='maintext']");
        readonly By registrationFailedBy = By.XPath("//div[contains(@class,'alert alert-error alert-danger')]");

        /// <summary>
        /// Metoda koja upisuje ime u odgovarajuce input polje
        /// </summary>
        /// <param name="firstName">Ime</param>
        private void EnterFirstName(string firstName) { WriteText(firstNameBy, firstName); }

        /// <summary>
        /// Metoda koja upisuje prezime u odgovarajuce input polje
        /// </summary>
        /// <param name="lastName">Prezime</param>
        private void EnterLastName(string lastName) { WriteText(lastNameBy, lastName); }

        /// <summary>
        /// Metoda koja upisuje email u odgovarajuce input polje
        /// </summary>
        /// <param name="email">Email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja upisuje broj telefona u odgovarajuce input polje
        /// </summary>
        /// <param name="telephone">Broj telefona</param>
        private void EnterTelephone(string telephone) { WriteText(telephoneBy, telephone); }

        /// <summary>
        /// Metoda koja upisuje faks u odgovarajuce input polje
        /// </summary>
        /// <param name="fax">Broj faksa</param>
        private void EnterFax(string fax) { WriteText(faxBy, fax); }

        /// <summary>
        /// Metoda koja upisuje kompaniju u odgovarajuce input polje
        /// </summary>
        /// <param name="company">Ime preduzeca</param>
        private void EnterCompany(string company) { WriteText(companyBy, company); }


        /// <summary>
        /// Metoda koja nasumicno selektuje drzavu
        /// </summary>
        private void SelectCountry()
        {
            SelectRandomElement(countryBy);
            //Thread.Sleep(1000);
        }

        /// <summary>
        /// Metoda koja selektuje drzavu
        /// </summary>
        /// <param name="countryName">Ime drzave</param>
        private void SelectCountry(string countryName)
        {
            if (!String.IsNullOrEmpty(countryName.ToLower()))
            {
                SelectElement select = new(_driver.FindElement(countryBy));
                select.SelectByText(countryName);
            }
        }

        /// <summary>
        /// Metoda koja nasumicno selektuje regiju
        /// </summary>
        private void SelectRegionState()
        {
            //Thread.Sleep(1000);
            SelectRandomElement(regionStateBy);
        }

        /// <summary>
        /// Metoda koja selektuje regiju
        /// </summary>
        /// <param name="regionName">Ime regije</param>
        private void SelectRegionState(string regionName)
        {
            if (!String.IsNullOrEmpty(regionName.ToLower()))
            {
                SelectElement select = new(_driver.FindElement(regionStateBy));
                select.SelectByText(regionName);
            }
        }


        /// <summary>
        /// Metoda koja upisuje City u odgovarajuce input polje
        /// </summary>
        /// <param name="city">Ime grada</param>
        private void EnterCity(string city) { WriteText(cityBy, city); }

        /// <summary>
        /// Metoda koja upisuje adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address1">Primarna adresa</param>
        private void EnterAddress1(string address1) { WriteText(address1By, address1); }

        /// <summary>
        /// Metoda koja upisuje drugu adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address2">Sekundarna adresa</param>
        private void EnterAddress2(string address2) { WriteText(address2By, address2); }

        /// <summary>
        /// Metoda koja upisuje Postal code u odgovarajuce input polje
        /// </summary>
        /// <param name="zipCode">Postanski broj</param>
        private void EnterZipCode(string zipCode) { WriteText(zipCodeBy, zipCode); }

        /// <summary>
        /// Metoda koja upisuje Loginname u odgovarajuce input polje
        /// </summary>
        /// <param name="loginName">Korisnicko login ime</param>
        private void EnterLoginName(string loginName) { WriteText(loginNameBy, loginName); }

        /// <summary>
        /// Metoda koja upisuje Password u odgovarajuca input polja
        /// </summary>
        /// <param name="password">Korisnicka sifra</param>
        private void EnterConfirmPassword(string password)
        {
            WriteText(passwordBy, password);
            WriteText(passwordConfirmBy, password);
        }

        /// <summary>
        /// Metoda koja pretplacuje korisnika na Newsletter
        /// </summary>
        /// <param name="subscription">True = Yes / False = No</param>
        private void SubscribeToNewsletter(bool subscription)
        {
            if (subscription) ClickElement(newsletterYesBy);
            else ClickElement(newsletterNoBy);
        }

        /// <summary>
        /// Metoda koja check-ira checkbox za Privacy Policy
        /// </summary>
        private void ClickAgreeOnPolicy() { ClickElement(privacyPolicyBy); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { /*Thread.Sleep(500);*/ ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja registruje korisnika tako sto popunjava sva neophodna
        /// polja forme i prosledjuje je klikom na Continue dugme
        /// </summary>
        public void RegisterWithRequiredOnly(
            string firstName,
            string lastName,
            string email,
            string address1,
            string city,
            string zipCode,
            string loginName,
            string password,
            bool subscription)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterAddress1(address1);
            SelectCountry();
            SelectRegionState();
            EnterCity(city);
            EnterZipCode(zipCode);
            EnterLoginName(loginName);
            EnterConfirmPassword(password);
            SubscribeToNewsletter(subscription);
            ClickAgreeOnPolicy();
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja vraca poruku o uspehu registracije korisnika.
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>poruku o uspehu</returns>
        public string GetSuccessMessage()
        {
            return ReadText(registationSuccessBy).Trim().ToLower();
        }

        /// <summary>
        /// Metoda koja vraca poruku o neuspesnoj registraciji korisnika
        /// </summary>
        /// <returns>poruku o neuspesnoj registraciji</returns>
        public string GetErrorMessage()
        {
            return ReadText(registrationFailedBy);
        }
    }
}
