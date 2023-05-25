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
        readonly By telephoneBy = By.Id("AccountFrm_telephone");
        readonly By faxBy = By.Id("AccountFrm_fax");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");

        /// <summary>
        /// Metoda koja vraca string iz telephone polja
        /// </summary>
        /// <returns></returns>
        public string GetTelephone()
        {
            return ReadValue(telephoneBy);
        }

        /// <summary>
        /// Metoda koja kupi sa input polja stari broj telefona
        /// korisnika, a umesto njega u input polje upisuje novi
        /// </summary>
        /// <param name = "newTelephone" >Novi broj telefona</param>
        /// <returns>stari broj telefona</returns>
        public string EnterTelephone(string newTelephone)
        {
            string oldTelephone = GetTelephone();
            WriteText(telephoneBy, newTelephone);
            return oldTelephone;
        }

        /// <summary>
        /// Metoda koja kupi sa input polja stari broj faksa
        /// korisnika, a umesto njega u input polje upisuje novi
        /// </summary>
        /// <param name = "newFax" >Novi faks</param>
        /// <returns>stari faks</returns>
        public string EnterFax(string newFax)
        {
            string oldFax = ReadText(faxBy);
            WriteText(telephoneBy, newFax);
            return oldFax;
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
