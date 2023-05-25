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
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public IndexPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        readonly By loginOrRegisterLinkBy = By.LinkText("Login or register");
        readonly By accountLinkBy = By.LinkText("Account");
        readonly By welcomeMessageBy = By.XPath("//div[@class='menu_text']");
        readonly By homePageLinkBy = By.LinkText("Home");
        readonly By contactUsLinkBy = By.LinkText("Contact Us");
        readonly By searchBoxBy = By.Id("filter_keyword");
        readonly By searchButtonBy = By.XPath("//div[@class='button-in-search']");
        readonly By cartBy = By.XPath("//ul[@id='main_menu_top']/li[@data-id='menu_cart']/a");
        readonly By cartBadgeBy = By.XPath("//a[@class='dropdown-toggle']/span[contains(@class,'label-orange font14')]");
        readonly By cartTotalBy = By.XPath("//a[@class='dropdown-toggle']/span[contains(@class,'cart_total')]");

        /// <summary>
        /// Metoda koja klikne na Login or register link
        /// </summary>
        public void ClickOnLoginOrRegister() { ClickElement(loginOrRegisterLinkBy); }

        /// <summary>
        /// Metoda koja klikne na account link
        /// </summary>
        public void ClickOnAccountLink() { ClickElement(accountLinkBy); }

        /// <summary>
        /// Metoda koja klikne na home page link
        /// </summary>
        public void ClickOnHomePageLink()
        {
            //Thread.Sleep(500);
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
        /// Metoda koja dodaje proizvod u korpu sa Index stranice
        /// na osnovu njihovog id-a
        /// </summary>
        /// <param name="itemId">Id proizvoda</param>
        public void AddProductFromIndex(string itemId = "50")
        {
            //Thread.Sleep(500);
            By item = By.XPath($"//a[@data-id='{itemId}']");

            if (CommonMethods.IsElementPresented(_driver, item))
                ClickElement(item);
        }

        /// <summary>
        /// Metoda koja klikne na proizvod sa Index stranice i ulazi na 
        /// Product stranicu na osnovu imena proizvoda
        /// </summary>
        /// <param name="itemName">Ime proizvoda</param>
        public void ClickOnProduct(string itemName = "ck one Summer 3.4 oz")
        {
            ClickElement(By.XPath($"//a[@title='{itemName}']"));
        }

        /// <summary>
        /// Metoda koja u Search Box upisuje ime proizvoda i trazi ga
        /// </summary>
        /// <param name="itemName">Ime proizvoda</param>
        public void SearchProduct(string itemName = "New French With Ease")
        {
            //Thread.Sleep(500);
            WriteText(searchBoxBy, itemName);
            ClickElement(searchButtonBy);
        }

        /// <summary>
        /// Metoda koja vraca broj proizvoda u korpi
        /// </summary>
        /// <returns>broj proizvoda u korpi</returns>
        public byte CartBadgeCount()
        {
            //Thread.Sleep(200);
            string countString = ReadText(cartBadgeBy);
            if (byte.TryParse(countString, out byte count))
            {
                return count;
            }
            return 0;
        }

        /// <summary>
        /// Metoda koja vraca ukupnu sumu korpe
        /// </summary>
        /// <returns>decimalan tip ukupne sumu korpe</returns>
        public decimal GetCartTotal()
        {
            return CommonMethods.PriceTextToDecimal(_driver, cartTotalBy);
        }

        /// <summary>
        /// Metoda koja konvertuje string cene proizvoda u decimalni tip
        /// </summary>
        /// <param name="itemId">Id proizvoda</param>
        /// <returns>decimalni tip cene proizvoda</returns>
        private decimal GetProductPrice(string itemId)
        {
            return CommonMethods.PriceTextToDecimal(
                _driver, By.XPath($"(//div[contains(@class, 'pricetag jumbotron')]/a[@data-id={itemId}]/..//div[@class='oneprice'])[1]"));
        }

        /// <summary>
        /// Metoda koja dodaje proizvod u korpu i vraca
        /// cenu dodatog proizvoda
        /// </summaryId proizvoda</param>
        /// <returns>decimalni tip cene proizvoda</returns>
        public decimal AddToTotal(string itemId)
        {
            AddProductFromIndex(itemId);
            return GetProductPrice(itemId);
        }

        /// <summary>
        /// Metoda koja cita tekst iz 'Welcome user' poruke
        /// Kopija poruke je trim-ovana i lowercase-ovana
        /// </summary>
        /// <returns>welcome user poruka</returns>
        public string GetWelcomeMessage()
        {
            return ReadText(welcomeMessageBy).Trim().ToLower();
        }
    }
}