using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class ContactUsPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ContactUsPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public ContactUsPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By firstNameBy = By.Id("ContactUsFrm_first_name");
        readonly By emailBy = By.Id("ContactUsFrm_email");
        readonly By enquiryBy = By.Id("ContactUsFrm_enquiry");
        readonly By submitButtonBy = By.XPath("//button[@title='Submit']");
        readonly By successfullyBy = By.XPath("//section[@class='mb40']/p[2]");

        /// <summary>
        /// Metoda koja upisuje ime u odredjeno input polje
        /// </summary>
        /// <param name="firstName">Ime</param>
        private void EnterFirtName(string firstName) { WriteText(firstNameBy, firstName); }

        /// <summary>
        /// Metoda koja upisuje _email u odredjeno input polje
        /// </summary>
        /// <param name="email">Kontakt email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja upisuje pitanje u odredjeno input polje
        /// </summary>
        /// <param name="enquiry">Pitanje ili upit korisnika</param>
        private void EnterEnquiry(string enquiry) { WriteText(enquiryBy, enquiry); }

        /// <summary>
        /// Metoda koja klikne na Submit dugme
        /// </summary>
        private void ClickOnSubmit() { ClickElement(submitButtonBy); }

        /// <summary>
        /// Metoda koja popunjava i salje Contact Us formu klikom na Submit dugme
        /// </summary>
        /// <param name="firstName">Ime</param>
        /// <param name="email">Kontakt email</param>
        /// <param name="enquiry">Pitanje ili upit korisnika</param>
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
        /// Metoda koja vraca poruku o uspesno popunjenoj Contact Us formi.
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>poruku o uspesno poslatoj formi</returns>
        public string GetSuccessMessage()
        {
            return ReadText(successfullyBy).Trim().ToLower();
        }
    }
}
