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
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public GuestCheckoutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By firstNameBy = By.Id("guestFrm_firstname");
        By lastNameBy = By.Id("guestFrm_lastname");
        By emailBy = By.Id("guestFrm_email");
        By telephoneBy = By.Id("guestFrmm_telephone");
        By faxBy = By.Id("guestFrm_fax");
        By companyBy = By.Id("guestFrm_company");
        By address1By = By.Id("guestFrm_address_1");
        By address2By = By.Id("guestFrm_address_2");
        By cityBy = By.Id("guestFrm_city");
        By regionStateBy = By.Id("guestFrm_zone_id");
        By regionStateOptionsBy = By.XPath("//select[@id='guestFrm_zone_id']/option");
        By zipCodeBy = By.Id("guestFrm_postcode");
        By countryBy = By.Id("guestFrm_country_id");
        By countryOptionsBy = By.XPath("select[@id='guestFrm_country_id']/option");
        By continueButtonBy = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja upisuje ime u odgovarajuce input polje
        /// </summary>
        /// <param name="firstName">First name</param>
        private void EnterFirstName(string firstName) { WriteText(firstNameBy, firstName); }

        /// <summary>
        /// Metoda koja upisuje prezime u odgovarajuce input polje
        /// </summary>
        /// <param name="lastName">Last name</param>
        private void EnterLastName(string lastName) { WriteText(lastNameBy, lastName); }

        /// <summary>
        /// Metoda koja upisuje email u odgovarajuce input polje
        /// </summary>
        /// <param name="email">Email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja upisuje broj telefona u odgovarajuce input polje
        /// </summary>
        /// <param name="telephone">Telephone number</param>
        private void EnterTelephone(string telephone) { WriteText(telephoneBy, telephone); }

        /// <summary>
        /// Metoda koja upisuje faks u odgovarajuce input polje
        /// </summary>
        /// <param name="fax">Fax number</param>
        private void EnterFax(string fax) { WriteText(faxBy, fax); }

        /// <summary>
        /// Metoda koja upisuje kompaniju u odgovarajuce input polje
        /// </summary>
        /// <param name="company">Company name</param>
        private void EnterCompany(string company) { WriteText(companyBy, company); }

        /// <summary>
        /// Metoda koja selektuje nasumicno drzavu
        /// </summary>
        private void SelectCountry(string country)
        {
            if (!String.IsNullOrEmpty(country.ToLower()))
            {
                SelectElement select = new SelectElement(driver.FindElement(countryBy));
                select.SelectByText(country);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Metoda koja selektuje nasumicno region
        /// </summary>
        private void SelectRegionState(string region)
        {
            if (!String.IsNullOrEmpty(region.ToLower()))
            {
                SelectElement select = new SelectElement(driver.FindElement(regionStateBy));
                select.SelectByText(region);
            }
        }

        /// <summary>
        /// Metoda koja upisuje grad u odgovarajuce input polje
        /// </summary>
        /// <param name="city">City name</param>
        private void EnterCity(string city) { WriteText(cityBy, city); }

        /// <summary>
        /// Metoda koja upisuje adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address1">First address</param>
        private void EnterAddress1(string address1) { WriteText(address1By, address1); }

        /// <summary>
        /// Metoda koja upisuje drugu adresu u odgovarajuce input polje
        /// </summary>
        /// <param name="address2">Second address</param>
        private void EnterAddress2(string address2) { WriteText(address2By, address2); }
        /// <summary>
        /// Metoda koja upisuje postanski kod u odgovarajuce input polje
        /// </summary>
        /// <param name="zipCode">Postal code</param>
        private void EnterZipCode(string zipCode) { WriteText(zipCodeBy, zipCode); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja registruje korisnika sa samo neophodnim podacima
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
