using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class ContactUsPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ContactUsPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ContactUsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By firstNameBy = By.Id("ContactUsFrm_first_name");
        By emailBy = By.Id("ContactUsFrm_email");
        By enquiryBy = By.Id("ContactUsFrm_enquiry");
        By submitButtonBy = By.XPath("//button[@title='Submit']");
        By successfullyBy = By.XPath("//section[@class='mb40']/p[2]");

        /// <summary>
        /// Metoda koja upisuje ime u odredjeno input polje
        /// </summary>
        /// <param name="firstName">First name</param>
        private void EnterFirtName(string firstName) { WriteText(firstNameBy, firstName); }

        /// <summary>
        /// Metoda koja upisuje email u odredjeno input polje
        /// </summary>
        /// <param name="email">Contact email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja upisuje pitanje u odredjeno input polje
        /// </summary>
        /// <param name="enquiry">Users enquiry</param>
        private void EnterEnquiry(string enquiry) { WriteText(enquiryBy, enquiry); }

        /// <summary>
        /// Metoda koja klikne na Submit dugme
        /// </summary>
        private void ClickOnSubmit() { ClickElement(submitButtonBy); }

        /// <summary>
        /// Metoda koja popunjava i salje Contact Us formu
        /// </summary>
        public void FilloutContactUsForm(
            string firstName,
            string email,
            string enquiry)
        {
            EnterFirtName(firstName);
            EnterEmail(email);
            EnterEnquiry(enquiry);
            ClickOnSubmit();
        }

        /// <summary>
        /// Metoda koja cita vraca tekst za uspesno poslat enquiry
        /// </summary>
        public string GetSuccessMessage()
        {
            return ReadText(successfullyBy).Trim().ToLower();
        }
    }
}
