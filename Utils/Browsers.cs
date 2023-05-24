using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomationFramework.Utils
{
    /// <summary>
    /// Klasa koja konfigurise browser 
    /// </summary>
    public class Browsers
    {
        private IWebDriver _webDriver;
        private readonly string _baseURL = "https://automationteststore.com/";

        /// <summary>
        /// Metoda koja pravi objekat odredjenog browsera, maximizira prozor i navigira na _baseURL
        /// </summary>
        public void Init()
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("ignore-certificate-errors");
            chromeOptions.AddArgument("start-maximized");
            _webDriver = new ChromeDriver(chromeOptions);

            Goto(_baseURL);
        }

        /// <summary>
        /// Getter metoda za _webDriver
        /// </summary>
        public IWebDriver GetDriver
        {
            get { return _webDriver; }
        }

        /// <summary>
        /// Metoda koja navigira _driver na odredjeni URL
        /// </summary>
        /// <param name="url">URL</param>
        public void Goto(string url)
        {
            //_webDriver.Url = url;
            _webDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Metoda koja gasi _driver
        /// </summary>
        public void Close()
        {
            _webDriver.Quit();
        }
    }
}
