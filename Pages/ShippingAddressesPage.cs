using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework.Pages
{
    public class ShippingAddressesPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ShippingAddressesPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ShippingAddressesPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        //Locators
        readonly By changeAdressButtonBy = By.XPath("//a[contains(@title,'Change Address')]");
        readonly By firstNameBy = By.Id("Address2Frm_firstname");
        readonly By lastNameBy = By.Id("Address2Frm_lastname");
        readonly By address1By = By.Id("Address2Frm_address_1");
        readonly By cityBy = By.Id("Address2Frm_city");
        readonly By regionStateBy = By.Id("Address2Frm_zone_id");
        readonly By regionStateOptionsBy = By.XPath("//select[@id='Address2Frm_zone_id']/option");
        readonly By zipCodeBy = By.Id("Address2Frm_postcode");
        readonly By countryBy = By.Id("Address2Frm_country_id");
        readonly By countryOptionsBy = By.XPath("select[@id='Address2Frm_country_id']/option");
        readonly By continueButtonBy = By.XPath("//button[contains(@class,'btn btn-orange pull-right lock-on-click')]");




        /// <summary>
        /// Metoda koja klikne na change address dugme
        /// </summary>
        public void ClickOnChangeAdress()
        {
            ClickElement(changeAdressButtonBy);
        }

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
        /// Metoda koja nasumicno selektuje drzavu
        /// </summary>
        private void SelectCountry()
        {
            SelectRandomElement(countryBy);
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
        /// Metoda koja upisuje Postal code u odgovarajuce input polje
        /// </summary>
        /// <param name="zipCode">Postanski broj</param>
        private void EnterZipCode(string zipCode) { WriteText(zipCodeBy, zipCode); }



        public void ChangeShippingAdress(string firstName,
            string lastName,
            string address,
            string city,
            string zipCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterAddress1(address);
            SelectCountry();
            SelectRegionState();
            EnterCity(city);
            EnterZipCode(zipCode);
        }
        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        public void ClickOnContinue() { ClickElement(continueButtonBy); }
    }
}
