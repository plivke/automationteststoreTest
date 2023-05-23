using AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class BasePage
    {
        // Driver
        public IWebDriver? driver;
        public WebDriverWait wait;


        /// <summary>
        /// Metoda koja ceka vidljivost elementa
        /// </summary>
        /// <param name="elementBy">lokator elementa</param>
        private void WaitElementVisibility(By elementBy)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementBy));
        }

        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        /// <param name="elementBy">lokator elementa</param>
        public void ClickElement(By elementBy)
        {
            WaitElementVisibility(elementBy);
            Thread.Sleep(200);
            CommonMethods.ClickOnElement(driver, elementBy);
        }

        /// <summary>
        /// Metoda koja upisuje tekst u polje
        /// </summary>
        /// <param name="elementBy">lokator elementa</param>
        /// <param name="text">tekst za upis</param>
        public void WriteText(By elementBy, string text)
        {
            WaitElementVisibility(elementBy);
            CommonMethods.WriteTextToElement(driver, elementBy, text);
        }

        /// <summary>
        /// Metoda koja cita tekst iz elementa
        /// </summary>
        /// <param name="elementBy">lokator elementa</param>
        public string ReadText(By elementBy)
        {
            WaitElementVisibility(elementBy);
            Thread.Sleep(500);
            return CommonMethods.ReadTextFromElement(driver, elementBy);
        }

    }
}
