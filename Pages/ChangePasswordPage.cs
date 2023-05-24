using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class ChangePasswordPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public ChangePasswordPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">_driver</param>
        public ChangePasswordPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By oldPasswordBy = By.Id("PasswordFrm_current_password");
        readonly By newPasswordBy = By.Id("PasswordFrm_password");
        readonly By confirmPasswordBy = By.Id("PasswordFrm_confirm");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");
        readonly By successMessageBy = By.XPath("//div[@class='alert alert-success']");

        /// <summary>
        /// Metoda koja upisuje staru sifru u odgovarajuce input polje
        /// </summary>
        /// <param name="oldPass"></param>
        private void EnterOldPassword(string oldPass)
        {
            WriteText(oldPasswordBy, oldPass);
        }

        /// <summary>
        /// Metoda koja upisuje novu sifru u odgovarajuce input polje
        /// </summary>
        /// <param name="oldPass"></param>
        private void EnterAndConfirmPassword(string newPass)
        {
            WriteText(newPasswordBy, newPass);
            WriteText(confirmPasswordBy, newPass);
        }

        /// <summary>
        /// Metoda koja klikne na Continue button
        /// </summary>
        private void ClickOnContinue()
        {
            ClickElement(continueButtonBy);
        }

        /// <summary>
        /// Metoda koja menja sifru
        /// </summary>
        /// <param name="oldPass">Stari korisnicki pass</param>
        /// <param name="newPass"></param>
        public void ChangePassword(string oldPass, string newPass)
        {
            EnterOldPassword(oldPass);
            EnterAndConfirmPassword(newPass);
            ClickOnContinue();
        }

        public string GetSuccessMessage()
        {
            return ReadText(successMessageBy).Trim().ToLower();
        }
    }
}
