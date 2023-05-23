using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class AccountForgottenPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountForgottenPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountForgottenPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By loginNameBy = By.Id("forgottenFrm_loginname");
        By lastNameBy = By.Id("forgottenFrm_lastname");
        By emailBy = By.Id("forgottenFrm_email");
        By continueButtonBy = By.XPath("//button[@title='Continue']");
        By successMessageBy = By.XPath("//div[contains(@class, 'alert-success')]");

        /// <summary>
        /// Metoda koja upisuje username u odgovarajuce polje
        /// </summary>
        /// <param name="loginName">Users login name</param>
        private void EnterLoginName(string loginName) { WriteText(loginNameBy, loginName); }

        /// <summary>
        /// Metoda koja upisuje prezime u odgovarajuce polje
        /// </summary>
        /// <param name="lastName">Users login name</param>
        private void EnterLastName(string lastName) { WriteText(lastNameBy, lastName); }


        /// <summary>
        /// Metoda koja upisuje email u odgovarajuce polje
        /// </summary>
        /// <param name="email">Users email</param>
        private void EnterEmail(string email) { WriteText(emailBy, email); }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        private void ClickOnContinue() { ClickElement(continueButtonBy); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="email"></param>
        public void ForgottenPasswordFillout(string loginName, string email)
        {
            EnterLoginName(loginName);
            EnterEmail(email);
            ClickOnContinue();
        }

        public void ForgottenLoginFillout(string lastName, string email)
        {
            EnterLastName(lastName);
            EnterEmail(email);
            ClickOnContinue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetSuccessMessage()
        {
            return ReadText(successMessageBy).Trim().ToLower();
        }
    }
}
