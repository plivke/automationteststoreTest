using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class BasePage
    {
        // Driver
        public IWebDriver? _driver;
        public WebDriverWait _wait;


        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        public void ClickElement(By elementBy)
        {
            Thread.Sleep(500);
            CommonMethods.ClickOnElement(_driver, elementBy);
        }

        /// <summary>
        /// Metoda koja upisuje tekst u polje
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        /// <param name="text">Tekst za upis</param>
        public void WriteText(By elementBy, string text)
        {
            CommonMethods.WriteTextToElement(_driver, elementBy, text);
        }

        /// <summary>
        /// Metoda koja cita tekst iz elementa
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        public string ReadText(By elementBy)
        {
            Thread.Sleep(500);
            return CommonMethods.ReadTextFromElement(_driver, elementBy);
        }

        /// <summary>
        /// Metoda koja cita tekst iz elementa
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        public string ReadValue(By elementBy)
        {
            Thread.Sleep(500);
            return CommonMethods.ReadValueFromElement(_driver, elementBy);
        }


        /// <summary>
        /// Metoda koja vrsi nasumicnu selekciju elemenata
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        public void SelectRandomElement(By elementBy)
        {
            CommonMethods.SelectRandomElement(_driver, elementBy);
        }
    }
}
