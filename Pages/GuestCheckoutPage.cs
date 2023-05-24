using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class GuestCheckoutPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public GuestCheckoutPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public GuestCheckoutPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By firstNameBy = By.Id("guestFrm_firstname");
        readonly By lastNameBy = By.Id("guestFrm_lastname");
        readonly By emailBy = By.Id("guestFrm_email");
        readonly By telephoneBy = By.Id("guestFrmm_telephone");
        readonly By faxBy = By.Id("guestFrm_fax");
        readonly By companyBy = By.Id("guestFrm_company");
        readonly By address1By = By.Id("guestFrm_address_1");
        readonly By address2By = By.Id("guestFrm_address_2");
        readonly By cityBy = By.Id("guestFrm_city");
        readonly By regionStateBy = By.Id("guestFrm_zone_id");
        readonly By regionStateOptionsBy = By.XPath("//select[@id='guestFrm_zone_id']/option");
        readonly By zipCodeBy = By.Id("guestFrm_postcode");
        readonly By countryBy = By.Id("guestFrm_country_id");
        readonly By countryOptionsBy = By.XPath("select[@id='guestFrm_country_id']/option");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja upisuje ime u odgovarajuce input polje
        /// </summary>
        /// <param name="firstName">Ime gosta</param>
        private void EnterFirstName(string firstName) { WriteText(firstNameBy, firstName); }

        /// <summary>
        /// Metoda koja upisuje prezime u odgovarajuce input polje
        /// </summary>
        /// <param name="lastName">Orezime gosta</param>
        private void EnterLastName(string lastName) { WriteText(lastNameBy, lastName); }

        /// <summary>
        /// Metoda koja upisuje email u odgovarajuce input polje
        /// </summary>
        /// <param name="email">Email gosta</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja upisuje broj telefona u odgovarajuce input polje
        /// </summary>
        /// <param name="telephone">Broj telefona</param>
        private void EnterTelephone(string telephone) { WriteText(telephoneBy, telephone); }

        /// <summary>
        /// Metoda koja upisuje broj faksa u odgovarajuce input polje
        /// </summary>
        /// <param name="fax">Broj faksa</param>
        private void EnterFax(string fax) { WriteText(faxBy, fax); }

        /// <summary>
        /// Metoda koja upisuje ime preduzeca u odgovarajuce input polje
        /// </summary>
        /// <param name="company">Ime preduzeca</param>
        private void EnterCompany(string company) { WriteText(companyBy, company); }

        /// <summary>
        /// Metoda koja nasumicno selektuje drzavu
        /// </summary>
        private void SelectCountry()
        {
            SelectRandomElement(countryBy);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Metoda koja selektuje drzavu po izboru
        /// </summary>
        /// <param name="country">Drzava</param>
        private void SelectCountry(string country)
        {
            if (!String.IsNullOrEmpty(country.ToLower()))
            {
                SelectElement select = new(_driver.FindElement(countryBy));
                select.SelectByText(country);
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Metoda koja nasumicno selektuje regiju
        /// </summary>
        private void SelectRegionState()
        {
            Thread.Sleep(1000);
            SelectRandomElement(regionStateBy);
        }

        /// <summary>
        /// Metoda koja selektuje regiju po izboru
        /// </summary>
        /// <param name="region">Regija</param>
        private void SelectRegionState(string region)
        {
            if (!String.IsNullOrEmpty(region.ToLower()))
            {
                SelectElement select = new(_driver.FindElement(regionStateBy));
                select.SelectByText(region);
            }
        }

        /// <summary>
        /// Metoda koja upisuje ime grada u odgovarajuce input polje
        /// </summary>
        /// <param name="city">Ime grad</param>
        private void EnterCity(string city) { WriteText(cityBy, city); }

        /// <summary>
        /// Metoda koja upisuje primarnu adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address1">Primarna adresa</param>
        private void EnterAddress1(string address1) { WriteText(address1By, address1); }

        /// <summary>
        /// Metoda koja upisuje sekundarnu adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address2">Sekundarna adresa</param>
        private void EnterAddress2(string address2) { WriteText(address2By, address2); }
        /// <summary>
        /// Metoda koja upisuje postanski broj u odgovarajuce input polje
        /// </summary>
        /// <param name="zipCode">Postanski broj</param>
        private void EnterZipCode(string zipCode) { WriteText(zipCodeBy, zipCode); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja vrsi Checkout gosta tako sto popunjava sva neophodna
        /// polja forme i prosledjuje je klikom na Continue dugme
        /// </summary>
        public void GuestCheckoutForm(
            string firstName,
            string lastName,
            string email,
            string address1,
            string city,
            string country,
            string region,
            string zipCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterAddress1(address1);
            SelectCountry(country);
            SelectRegionState(region);
            EnterCity(city);
            EnterZipCode(zipCode);
            ClickOnContinue();
        }
    }
}
