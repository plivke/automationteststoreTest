using AutomationFramework.Utils;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class IndexPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public IndexPage()
        {
            driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public IndexPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Locators
        By loginOrRegisterLinkBy = By.LinkText("Login or register");
        By welcomeMessageBy = By.XPath("//div[@class='menu_text']");
        By homePageLinkBy = By.LinkText("Home");
        By contactUsLinkBy = By.LinkText("Contact Us");
        By cartBy = By.XPath("//ul[@id='main_menu_top']/li[@data-id='menu_cart']/a");
        By searchBoxBy = By.Id("filter_keyword");
        By searchButtonBy = By.XPath("//div[@class='button-in-search']");

        /// <summary>
        /// Metoda koja klikne na Login or register link
        /// </summary>
        public void ClickOnLoginOrRegister() { ClickElement(loginOrRegisterLinkBy); }

        /// <summary>
        /// Metoda koja klikne na home page link
        /// </summary>
        public void ClickOnHomePageLink()
        {
            Thread.Sleep(500);
            ClickElement(homePageLinkBy);
        }

        /// <summary>
        /// Metoda koja klikne na Contact Us link
        /// </summary>
        public void ClickOnContactUs() { ClickElement(contactUsLinkBy); }

        /// <summary>
        /// Metoda koja klikne na link za korpu
        /// </summary>
        public void ClickOnCartPageLink() { ClickElement(cartBy); }


        /// <summary>
        /// Metoda koja dodaje proizvode u korpu sa indeks strane
        /// na osnovu njihovog id-a
        /// </summary>
        /// <param name="itemId">Id proizvoda</param>
        public void AddProductFromIndex(string itemId = "50")
        {
            Thread.Sleep(500);
            ClickElement(By.XPath($"//a[@data-id='{itemId}']"));
        }

        /// <summary>
        /// Metoda koja dodaje proizvode u korpu sa indeks strane
        /// na osnovu njihovih imena
        /// </summary>
        /// <param name="itemName">Ime proizvoda</param>
        public void ClickOnProduct(string itemName = "ck one Summer 3.4 oz")
        {
            ClickElement(By.XPath($"//a[@title='{itemName}']"));
        }

        /// <summary>
        /// Metoda koja u Search Box upisuje ime proizvoda i trazi ga
        /// </summary>
        /// <param name="itemName"></param>
        public void SearchProduct(string itemName = "New French With Ease")
        {
            Thread.Sleep(500);
            WriteText(searchBoxBy, itemName);
            ClickElement(searchButtonBy);
        }

        /// <summary>
        /// Metoda koja cita tekst iz 'welcome user' poruke
        /// </summary>
        /// <returns>Welcome user poruka</returns>
        public string GetWelcomeMessage()
        {
            Thread.Sleep(500);
            return CommonMethods.ReadTextFromElement(driver, welcomeMessageBy).ToLower();
        }

    }
}

