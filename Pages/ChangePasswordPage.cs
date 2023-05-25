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
        /// <param name="oldPass">Stara korisnicka sifra</param>
        private void EnterOldPassword(string oldPass)
        {
            WriteText(oldPasswordBy, oldPass);
        }

        /// <summary>
        /// Metoda koja upisuje novu sifru u dva odgovarajuca input polja
        /// </summary>
        /// <param name="newPass">Nova korisnicka sifra</param>
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
        /// Metoda koja menja korisnikovu sifru nakon cega
        /// klikne na Continue dugme
        /// </summary>
        /// <param name="oldPass">Stari korisnicki sifra</param>
        /// <param name="newPass">Nova korisnicka sifra</param>
        public void ChangePassword(string oldPass, string newPass)
        {
            EnterOldPassword(oldPass);
            EnterAndConfirmPassword(newPass);
            ClickOnContinue();
        }

        /// <summary>
        /// Metoda koja vraca poruku o uspesno izmenjenoj sifri
        /// </summary>
        /// <returns>poruka o uspehu</returns>
        public string GetSuccessMessage()
        {
            return ReadText(successMessageBy).Trim().ToLower();
        }
    }
}
