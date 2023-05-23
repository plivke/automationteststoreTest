using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class AccountCreatePage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountCreatePage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountCreatePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By firstNameBy = By.Id("AccountFrm_firstname");
        By lastNameBy = By.Id("AccountFrm_lastname");
        By emailBy = By.Id("AccountFrm_email");
        By telephoneBy = By.Id("AccountFrm_telephone");
        By faxBy = By.Id("AccountFrm_fax");
        By companyBy = By.Id("AccountFrm_company");
        By address1By = By.Id("AccountFrm_address_1");
        By address2By = By.Id("AccountFrm_address_2");
        By cityBy = By.Id("AccountFrm_city");
        By regionStateBy = By.Id("AccountFrm_zone_id");
        By regionStateOptionsBy = By.XPath("//select[@id='AccountFrm_zone_id']/option");
        By zipCodeBy = By.Id("AccountFrm_postcode");
        By countryBy = By.Id("AccountFrm_country_id");
        By countryOptionsBy = By.XPath("select[@id='AccountFrm_country_id']/option");
        By loginNameBy = By.Id("AccountFrm_loginname");
        By passwordBy = By.Id("AccountFrm_password");
        By passwordConfirmBy = By.Id("AccountFrm_confirm");
        By newsletterYesBy = By.Id("AccountFrm_newsletter1");
        By newsletterNoBy = By.Id("AccountFrm_newsletter0");
        By privacyPolicyBy = By.Id("AccountFrm_agree");
        By continueButtonBy = By.XPath("//button[@title='Continue']");
        By registationSuccessBy = By.XPath("//span[@class='maintext']");

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
        private void SelectCountry(string country = "Yugoslavia")
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
        private void SelectRegionState(string region = "Vojvodina")
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
        /// Metoda koja upisuje username u odgovarajuce input polje
        /// </summary>
        /// <param name="loginName">Users login name</param>
        private void EnterLoginName(string loginName) { WriteText(loginNameBy, loginName); }

        /// <summary>
        /// Metoda koja upisuje password u odgovarajuca input polja
        /// </summary>
        /// <param name="password">Users password</param>
        private void EnterConfirmPassword(string password)
        {
            WriteText(passwordBy, password);
            Thread.Sleep(500);
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
        /// Metoda koja stiklira checkbox za Privacy Policy
        /// </summary>
        private void ClickAgreeOnPolicy() { ClickElement(privacyPolicyBy); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// Metoda koja registruje korisnika sa samo neophodnim podacima
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
        /// Metoda koja vraca poruku o uspehu
        /// </summary>
        /// <returns>Vraca poruku o uspehu</returns>
        public string GetSuccessMessage()
        {
            Thread.Sleep(500);
            return CommonMethods.ReadTextFromElement(driver, registationSuccessBy).Trim().ToLower();
        }
    }
}
